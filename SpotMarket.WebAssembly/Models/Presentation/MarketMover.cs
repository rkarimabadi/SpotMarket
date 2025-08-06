namespace SpotMarket.WebAssembly.Models.Presentation
{

    /// <summary>
    /// نمایانگر یک آیتم در لیست‌های پویایی بازار است
    /// </summary>
    public class MarketMoverItem
    {
        public int Rank { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public ValueState ValueState { get; set; } = ValueState.Neutral;
    }

    /// <summary>
    /// وضعیت مقدار را برای تعیین رنگ (مثبت، منفی، خنثی) مشخص می‌کند
    /// </summary>
    public enum ValueState { Neutral, Positive, Negative  }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت پویایی بازار
    /// </summary>
    public class MarketMoversData
    {
        public string CompetitionTabTitle { get; set; } = "داغ‌ترین رقابت‌ها";
        public string DemandTabTitle { get; set; } = "بیشترین تقاضا";
        public List<MarketMoverItem> CompetitionItems { get; set; } = new();
        public List<MarketMoverItem> DemandItems { get; set; } = new();
    }

}
