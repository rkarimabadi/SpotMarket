namespace SpotMarket.WebAssembly.Models.Presentation
{

    /// <summary>
    /// مدل برای ویجت "مسیر سریع"
    /// </summary>
    public class QuickPathItem
    {
        public string Title { get; set; } = string.Empty;
        public string UrlName { get; set; } = string.Empty;
        public string IconCssClass { get; set; } = string.Empty;
        public string ThemeCssClass { get; set; } = string.Empty;
    }

    /// <summary>
    /// مدل برای نمایش وضعیت گروه‌های اصلی سیمان
    /// </summary>
    public class CementGroupStatusItem
    {
        public string Name { get; set; } = string.Empty; // نام گروه، مثلا "سیمان پرتلند تیپ 2"
        public string Subtitle { get; set; } = string.Empty; // اطلاعات زیرگروه، مثلا "سیمان تهران، سیمان آبیک"
        public string UrlName { get; set; } = string.Empty;
        public GroupActivityStatus Status { get; set; } = GroupActivityStatus.Inactive;
        public int? OfferCount { get; set; }
        public DemandStatus DemandStatus { get; set; } = DemandStatus.Medium;
    }

    /// <summary>
    /// مدل برای نگهداشتن کل داده‌های صفحه فرود
    /// </summary>
    public class CementLandingPageData
    {
        public string MarketSummaryValue { get; set; } = string.Empty;
        public string MarketSummaryLabel { get; set; } = string.Empty;
        public string MarketSummarySubtitle { get; set; } = string.Empty;

        public List<QuickPathItem> QuickPathItems { get; set; } = new();
        public List<CementGroupStatusItem> ActiveGroups { get; set; } = new();
        public List<CementGroupStatusItem> InactiveGroups { get; set; } = new();

        public int InactiveGroupsCount => InactiveGroups.Count;
        public bool HasInactiveGroups => InactiveGroups.Any();
    }
}
