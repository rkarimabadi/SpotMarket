namespace SpotMarket.Shared.Models.Presentation
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

    public class BasicCementMarketSummary
    {
        public string Value { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
    }
    public class CementMarketSummary
    {
        public string TotalValue { get; set; } = string.Empty;
        public string TotalVolume { get; set; } = string.Empty;
        public int TodayOffersCount { get; set; }
        public string CompetitionValue { get; set; } = string.Empty;
        public double CompetitionPercentage { get; set; }
        public string DemandValue { get; set; } = string.Empty;
        public double DemandPercentage { get; set; }
        public bool IsPositive { get; set; }
    }
    public class CementQuickPathData
    {
        public List<QuickPathItem> Items { get; set; } = new();
    }
    public class CementGroupsData
    {
        public List<CementGroupStatusItem> ActiveGroups { get; set; } = new();
        public List<CementGroupStatusItem> InactiveGroups { get; set; } = new();

        public int InactiveGroupsCount => InactiveGroups.Count;
        public bool HasInactiveGroups => InactiveGroups.Any();
    }
}
