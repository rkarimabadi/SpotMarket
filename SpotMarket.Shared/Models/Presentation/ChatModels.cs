namespace SpotMarket.Shared.Models.Presentation
{
    /// <summary>
    /// نقش یک پیام در گفتگو. مقادیر با قرارداد سمت سرور یکسان است.
    /// </summary>
    public static class ChatRoles
    {
        public const string User = "user";
        public const string Assistant = "assistant";
        public const string System = "system";
    }

    /// <summary>
    /// یک پیام از تاریخچه گفتگو که به سرور ارسال می‌شود.
    /// سرور وضعیتی نگه نمی‌دارد؛ کلاینت در هر درخواست تاریخچه را می‌فرستد.
    /// </summary>
    public class ChatMessageDto
    {
        public string Role { get; set; } = ChatRoles.User;
        public string Content { get; set; } = string.Empty;
    }

    /// <summary>
    /// بدنه درخواست اندپوینت‌های گفتگو
    /// </summary>
    public class ChatRequest
    {
        public IReadOnlyList<ChatMessageDto> Messages { get; set; } = [];
    }

    /// <summary>
    /// پاسخ غیرجریانی سرور به یک پیام کاربر
    /// </summary>
    public class ChatResponse
    {
        public string Reply { get; set; } = string.Empty;
        public bool IsError { get; set; }

        /// <summary>
        /// توابعی که برای ساخت این پاسخ فراخوانی شده‌اند — برای نمایش منبع داده
        /// </summary>
        public IReadOnlyList<ToolUsage> UsedTools { get; set; } = [];
    }

    /// <summary>
    /// یک تابع فراخوانی‌شده به همراه نام نمایشی فارسی آن
    /// </summary>
    public class ToolUsage
    {
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }

    /// <summary>
    /// توصیف یک تابع در دسترس دستیار — خروجی اندپوینت capabilities
    /// </summary>
    public class ChatToolInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    /// <summary>
    /// معرفی قابلیت‌های دستیار: فعال بودن، نمونه پرسش‌ها و فهرست توابع.
    /// صفحه گفتگو محتوای حالت خالی را از همین می‌سازد و چیزی را در کلاینت ثابت نمی‌کند.
    /// </summary>
    public class ChatCapabilities
    {
        /// <summary>اگر false باشد تنظیمات مدل ناقص است و اندپوینت گفتگو ۵۰۳ برمی‌گرداند.</summary>
        public bool IsEnabled { get; set; }

        /// <summary>حداکثر تعداد پیام‌هایی که سرور از تاریخچه به مدل می‌دهد.</summary>
        public int MaxHistoryMessages { get; set; }

        public IReadOnlyList<string> SampleQuestions { get; set; } = [];
        public IReadOnlyList<ChatToolInfo> Tools { get; set; } = [];
    }

    /// <summary>
    /// انواع رویداد جریان پاسخ (SSE)
    /// </summary>
    public static class ChatStreamEventTypes
    {
        /// <summary>مدل یک تابع داده را فراخوانی کرد — برای نمایش «در حال دریافت داده…»</summary>
        public const string Tool = "tool";

        /// <summary>یک تکه از متن پاسخ</summary>
        public const string Delta = "delta";

        /// <summary>پایان موفق جریان</summary>
        public const string Done = "done";

        /// <summary>خطا در تولید پاسخ</summary>
        public const string Error = "error";

        /// <summary>
        /// نسخه‌ی اصلاح‌شده‌ی کل پاسخ — متنی که تا این لحظه از رویدادهای delta ساخته شده
        /// باید یک‌جا با <c>Text</c> جایگزین شود.
        ///
        /// سرور نگهبان زبان فارسی دارد که فقط پس از کامل‌شدن متن می‌تواند قضاوت کند، ولی تا
        /// آن لحظه تکه‌ها فرستاده شده‌اند. این رویداد اختیاری است و فقط وقتی می‌آید که
        /// واقعاً اصلاحی انجام شده باشد.
        /// </summary>
        public const string Correction = "correction";
    }

    /// <summary>
    /// یک رویداد در جریان پاسخ. بسته به <see cref="Type"/> تنها بخشی از فیلدها معنا دارند:
    /// tool ← Tool و ToolTitle، delta و error ← Text، done ← بدون فیلد.
    /// </summary>
    public class ChatStreamEvent
    {
        public string Type { get; set; } = string.Empty;
        public string? Text { get; set; }
        public string? Tool { get; set; }
        public string? ToolTitle { get; set; }
    }

    /// <summary>
    /// مشخصات نموداری که دستیار داخل بلاک ```chart پیشنهاد می‌دهد و کلاینت آن را رسم می‌کند
    /// </summary>
    public class ChartSpec
    {
        /// <summary>bar برای مقایسه دسته‌ها، line برای روند زمانی</summary>
        public string Type { get; set; } = "bar";

        public string? Title { get; set; }

        /// <summary>واحد مقادیر، مثلاً «همت» یا «تن»</summary>
        public string? Unit { get; set; }

        public IReadOnlyList<string> Labels { get; set; } = [];
        public IReadOnlyList<ChartSeries> Series { get; set; } = [];
    }

    public class ChartSeries
    {
        public string? Name { get; set; }
        public IReadOnlyList<double> Values { get; set; } = [];
    }
}
