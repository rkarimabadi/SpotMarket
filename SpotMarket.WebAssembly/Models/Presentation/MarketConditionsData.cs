namespace SpotMarket.WebAssembly.Models.Presentation
{
    /// <summary>
    /// نمایانگر یک آیتم (باکس) در ویجت شرایط بازار است
    /// </summary>
    public class MarketConditionItem
    {
        public string Title { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string? Unit { get; set; }
        public string IconCssClass { get; set; } = string.Empty;
        public string IconBgCssClass { get; set; } = string.Empty;
        public ValueState ValueState { get; set; } = ValueState.Neutral;
    }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت شرایط بازار
    /// </summary>
    public class MarketConditionsData
    {
        
        public List<MarketConditionItem> Items { get; set; } = new();
    }
}
