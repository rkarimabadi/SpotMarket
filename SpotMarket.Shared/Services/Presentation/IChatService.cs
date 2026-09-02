using SpotMarket.Shared.Models.Presentation;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface IChatService
    {
        /// <summary>
        /// معرفی قابلیت‌های دستیار برای ساخت صفحه خالی گفتگو
        /// </summary>
        Task<ChatCapabilities?> GetCapabilitiesAsync(CancellationToken ct = default);

        /// <summary>
        /// گفتگوی جریانی روی SSE. رویدادها به‌ترتیب رسیدن بازگردانده می‌شوند تا کاربر
        /// ابتدا ببیند کدام داده در حال واکشی است و سپس متن را کلمه‌به‌کلمه.
        /// </summary>
        IAsyncEnumerable<ChatStreamEvent> StreamAsync(IReadOnlyList<ChatMessageDto> messages, CancellationToken ct = default);

        /// <summary>
        /// گفتگوی یک‌جا؛ تنها به‌عنوان جایگزین وقتی جریان در دسترس نیست.
        /// </summary>
        Task<ChatResponse?> SendAsync(IReadOnlyList<ChatMessageDto> messages, CancellationToken ct = default);
    }
}
