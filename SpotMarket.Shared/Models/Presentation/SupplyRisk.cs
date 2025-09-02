namespace SpotMarket.Shared.Models.Presentation
{
    /// <summary>
    /// سطوح مختلف ریسک را مشخص می‌کند
    /// </summary>
    public enum RiskLevel
    {
        High,
        Medium,
        Low
    }

    /// <summary>
    /// نمایانگر یک آیتم در لیست ویجت ریسک عرضه است
    /// </summary>
    public class SupplyRiskItem
    {
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public RiskLevel RiskLevel { get; set; }
        public string Value { get; set; } = string.Empty;
        public int CommodityId { get; set; }
    }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت ریسک عرضه
    /// </summary>
    public class SupplyRiskData
    {
        public IEnumerable<SupplyRiskItem> Items { get; set; } = new List<SupplyRiskItem>();
    }
}
