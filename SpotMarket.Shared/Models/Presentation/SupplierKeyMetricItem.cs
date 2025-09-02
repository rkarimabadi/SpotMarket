namespace SpotMarket.Shared.Models.Presentation
{
    public class SupplierKeyMetricsData
    {
        public List<SupplierKeyMetricItem> Items { get; set; } = new();
    }
    public class SupplierKeyMetricItem
    {
        public string Title { get; set; } = string.Empty;       // e.g., "کالای استراتژیک"
        public string Name { get; set; } = string.Empty;        // e.g., "شمش فولادی"
        public string StatValue { get; set; } = string.Empty;   // e.g., "سهم ۳۴٪"
        public string IconCssClass { get; set; } = string.Empty; // e.g., "bi bi-trophy-fill"
        public int? LinkId { get; set; }                         // Optional ID for navigation
        public string LinkType { get; set; } = string.Empty;     // "commodity" or "broker"
    }
}
