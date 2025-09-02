namespace SpotMarket.Shared.Models.Presentation
{
    public class MarketStatItem
    {
        public string Value { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string IconCssClass { get; set; } = string.Empty;
        public string ThemeCssClass { get; set; } = string.Empty;
        public ValueState ValueState { get; set; } = ValueState.Neutral;
    }

    // مدل اصلی که لیستی از آیتم‌های آماری را نگهداری می‌کند
    public class MarketStatsData
    {
        public List<MarketStatItem> Items { get; set; } = new();
    }
}
