namespace SpotMarket.WebAssembly.Models.Presentation
{
    public record SearchResult(
        int Id,
        string Title,
        string Subtitle,
        string Icon,
        string IconCssClass,
        string NavigationUrl
    );
    /// <summary>
    /// نوع موجودیت پیدا شده در نتایج جستجو را مشخص می‌کند.
    /// </summary>
    public enum SearchResultType
    {
        Commodity,
        SubGroup,
        Group,
        MainGroup,
        Broker,
        Supplier,
        Manufacturer
    }

    /// <summary>
    /// مدل داده خام برای یک آیتم در نتایج جستجو که توسط API ارسال می‌شود.
    /// این مدل فاقد جزئیات نمایشی مانند آیکون است.
    /// </summary>
    public class SearchResultItem
    {
        /// <summary>
        /// شناسه موجودیت (مثلاً شناسه کالا یا کارگزار)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// عنوان اصلی نتیجه (مثلاً "میلگرد" یا "کارگزاری مفید")
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// زیرنویس برای توضیح نوع نتیجه (مثلاً "کالا" یا "کارگزار")
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// نوع شمارشی برای کمک به کلاینت در مپ کردن به مدل نمایشی
        /// </summary>
        public SearchResultType ResultType { get; set; }
    }

    /// <summary>
    /// نگهدارنده لیست نتایج جستجو برای ارسال به کلاینت.
    /// </summary>
    public class SearchResultsData
    {
        public List<SearchResultItem> Items { get; set; } = new();
    }
}
