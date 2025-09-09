namespace SpotMarket.Shared.Models.Presentation
{
    /// <summary>
    /// نمایانگر یک کارت در ویجت تالارهای معاملاتی است
    /// </summary>
    public class TradingHallItem
    {
        public string Title { get; set; } = string.Empty;
        public string IconCssClass { get; set; } = string.Empty;
        public string IconBgCssClass { get; set; } = string.Empty;
        public string ValueLabel { get; set; } = "ارزش معاملات";
        public string Value { get; set; } = string.Empty;
        public string Change { get; set; } = string.Empty;
        public ValueState ChangeState { get; set; } = ValueState.Neutral;
    }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت تالارهای معاملاتی
    /// </summary>
    public class TradingHallsData
    {
        public IEnumerable<TradingHallItem> Items { get; set; } = [];
        public string? EffectiveDate { get; set; }
        public bool IsForToday { get; set; }
    }
}
