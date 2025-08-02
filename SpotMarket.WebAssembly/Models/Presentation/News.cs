namespace SpotMarket.WebAssembly.Models.Presentation
{
    /// <summary>
    /// دسته‌بندی‌های مختلف اخبار را مشخص می‌کند
    /// </summary>
    public enum NewsCategory
    {
        HotGroup,
        SupplyAnnouncement,
        MarketAnalysis
    }

    /// <summary>
    /// گروه‌های اصلی بازار برای تخصیص آیکون مناسب
    /// </summary>
    public enum MarketGroup
    {
        Steel,
        Petrochemical,
        Cement,
        Agriculture,
        General
    }

    /// <summary>
    /// نمایانگر یک آیتم خبری در لیست است
    /// </summary>
    public class NewsItem
    {
        public string Title { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public NewsCategory Category { get; set; }
        public MarketGroup MarketGroup { get; set; }
    }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت اخبار
    /// </summary>
    public class NewsData
    {
        public string ActionText { get; set; } = "بیشتر";
        public string ActionLink { get; set; } = "/news";
        public List<NewsItem> Items { get; set; } = new();
    }
}
