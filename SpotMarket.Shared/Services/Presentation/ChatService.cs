using SpotMarket.Shared.Models.Presentation;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace SpotMarket.Shared.Services.Presentation
{
    public class ChatService : IChatService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/chat";

        /// <summary>
        /// بدون این گزینه، هندلر HTTP مرورگر کل پاسخ را بافر می‌کند و رویدادهای SSE
        /// یک‌جا در پایان می‌رسند. مقدار کلید همان چیزی است که
        /// SetBrowserResponseStreamingEnabled تنظیم می‌کند؛ اینجا مستقیم نوشته شده تا
        /// پروژه اشتراکی به بسته مخصوص WebAssembly وابسته نشود. سایر هندلرها آن را نادیده می‌گیرند.
        /// </summary>
        private static readonly HttpRequestOptionsKey<bool> BrowserResponseStreaming = new("WebAssemblyEnableStreamingResponse");

        private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

        public ChatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ChatCapabilities?> GetCapabilitiesAsync(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<ChatCapabilities>($"{_controllerPath}/capabilities", ct);
        }

        public async Task<ChatResponse?> SendAsync(IReadOnlyList<ChatMessageDto> messages, CancellationToken ct = default)
        {
            var response = await _httpClient.PostAsJsonAsync(_controllerPath, new ChatRequest { Messages = messages }, ct);
            // سرور برای خطاهای شناخته‌شده (۴۰۰ و ۵۰۳) هم بدنه ChatResponse با IsError برمی‌گرداند.
            return await response.Content.ReadFromJsonAsync<ChatResponse>(JsonOptions, ct);
        }

        public async IAsyncEnumerable<ChatStreamEvent> StreamAsync(
            IReadOnlyList<ChatMessageDto> messages,
            [EnumeratorCancellation] CancellationToken ct = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, $"{_controllerPath}/stream")
            {
                Content = JsonContent.Create(new ChatRequest { Messages = messages })
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
            request.Options.Set(BrowserResponseStreaming, true);

            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);

            // محدودیت نرخ پاسخ SSE برنمی‌گرداند، پس پیش از خواندن جریان جدا مدیریت می‌شود.
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                yield return new ChatStreamEvent
                {
                    Type = ChatStreamEventTypes.Error,
                    Text = "تعداد درخواست‌ها بیش از حد مجاز است. کمی بعد دوباره تلاش کنید."
                };
                yield break;
            }

            using var stream = await response.Content.ReadAsStreamAsync(ct);
            using var reader = new StreamReader(stream);

            var received = false;
            while (true)
            {
                var line = await reader.ReadLineAsync(ct);
                if (line is null) break;
                if (!line.StartsWith("data:", StringComparison.Ordinal)) continue;

                var payload = line[5..].TrimStart();
                if (payload.Length == 0) continue;

                ChatStreamEvent? evt = null;
                try
                {
                    evt = JsonSerializer.Deserialize<ChatStreamEvent>(payload, JsonOptions);
                }
                catch (JsonException)
                {
                    // یک رویداد ناقص نباید کل گفتگو را از کار بیندازد.
                }

                if (evt is null) continue;

                received = true;
                yield return evt;

                if (evt.Type == ChatStreamEventTypes.Done) yield break;
            }

            // پاسخی که هیچ رویداد معتبری نداشت یعنی خطای غیرمنتظره سمت سرور یا پروکسی.
            if (!received)
            {
                yield return new ChatStreamEvent
                {
                    Type = ChatStreamEventTypes.Error,
                    Text = "پاسخی از سرویس گفتگو دریافت نشد."
                };
            }
        }
    }
}
