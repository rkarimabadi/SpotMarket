using Microsoft.JSInterop;
using SpotMarket.Shared.Models.Presentation;
using System.Text.Json;

namespace SpotMarket.Shared.Services.App
{
    /// <summary>
    /// تاریخچه گفتگو را در حافظه محلی مرورگر نگه می‌دارد.
    ///
    /// سرور گفتگو وضعیتی ذخیره نمی‌کند، پس اگر کلاینت تاریخچه را نگه ندارد با هر بار
    /// جابه‌جایی بین تب‌های پایین صفحه، گفتگو از ابتدا شروع می‌شود.
    /// </summary>
    public class ChatHistoryService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string HistoryKey = "chatHistory";

        /// <summary>
        /// سقف پیام‌های ذخیره‌شده. تاریخچه فقط برای ادامه دادن گفتگوست و نگه داشتن
        /// بی‌انتهای آن هم حافظه محلی را پر می‌کند و هم حجم درخواست را بالا می‌برد.
        /// </summary>
        private const int MaxStoredMessages = 60;

        /// <summary>
        /// پرسشی که کاربر جای دیگری (مثلاً ویجت دستیار در داشبورد) نوشته و قرار است
        /// گفتگو با آن در صفحه گفتگو شروع شود. صفحه گفتگو آن را می‌خواند و خالی می‌کند.
        /// </summary>
        public string? PendingQuestion { get; set; }

        public ChatHistoryService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<List<ChatMessageDto>> LoadAsync(CancellationToken ct = default)
        {
            try
            {
                var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", ct, HistoryKey);
                if (string.IsNullOrEmpty(json)) return new List<ChatMessageDto>();
                return JsonSerializer.Deserialize<List<ChatMessageDto>>(json) ?? new List<ChatMessageDto>();
            }
            catch
            {
                return new List<ChatMessageDto>();
            }
        }

        public async Task SaveAsync(IEnumerable<ChatMessageDto> messages, CancellationToken ct = default)
        {
            var trimmed = messages.TakeLast(MaxStoredMessages).ToList();
            var json = JsonSerializer.Serialize(trimmed);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", ct, HistoryKey, json);
        }

        public async Task ClearAsync(CancellationToken ct = default)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", ct, HistoryKey);
        }
    }
}
