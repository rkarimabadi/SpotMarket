using SpotMarket.Shared.Models.Presentation;

namespace SpotMarket.Shared.Models.App
{
    /// <summary>
    /// یک پیام همان‌طور که در صفحه گفتگو نمایش داده می‌شود.
    ///
    /// با <see cref="ChatMessageDto"/> یکی نیست: آن قرارداد ارسال به سرور است و این وضعیت
    /// نمایشی کلاینت، شامل توابعی که پاسخ از آن‌ها ساخته شده و اینکه پیام هنوز در حال
    /// دریافت است یا با خطا تمام شده.
    /// </summary>
    public class ChatUiMessage
    {
        public string Role { get; set; } = ChatRoles.User;

        /// <summary>متن پیام؛ برای پاسخ دستیار حین جریان تکه‌تکه کامل می‌شود.</summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>توابعی که پاسخ از داده آن‌ها ساخته شده — برای نمایش منبع داده.</summary>
        public List<ToolUsage> UsedTools { get; set; } = new();

        /// <summary>پاسخ هنوز شروع نشده است (فقط نشانگر انتظار نمایش داده می‌شود).</summary>
        public bool IsPending { get; set; }

        /// <summary>پیام حاصل خطاست و نباید در تاریخچه ارسالی به سرور بیاید.</summary>
        public bool IsError { get; set; }

        public bool IsUser => Role == ChatRoles.User;
    }
}
