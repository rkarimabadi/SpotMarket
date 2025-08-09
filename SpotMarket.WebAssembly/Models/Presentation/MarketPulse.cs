namespace SpotMarket.WebAssembly.Models.Presentation
{
    /// <summary>
    /// نمایانگر هر کارت در ویجت نبض بازار است
    /// </summary>
    public class PulseCardItem
    {
        public string Title { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Change { get; set; } = string.Empty;
        public string ChangeLabel { get; set; } = string.Empty; 

        public ValueState ChangeState { get; set; } = ValueState.Neutral;
    }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت نبض بازار
    /// </summary>
    public class MarketPulseData
    {
        public List<PulseCardItem> Items { get; set; } = new();
    }
}
