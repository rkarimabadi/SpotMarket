namespace SpotMarket.Shared.Models.Presentation
{
    /// <summary>
    /// نگهدارنده داده‌های جدول تحلیل کالاهای عرضه‌شده توسط یک تامین‌کننده
    /// </summary>
    public class SupplierCommodityAnalysisData
    {
        public List<SupplierCommodityAnalysisItem> Items { get; set; } = new();
    }

    /// <summary>
    /// نمایانگر یک سطر (یک کالا) در جدول تحلیل کالاها
    /// </summary>
    public class SupplierCommodityAnalysisItem
    {
        public int CommodityId { get; set; }
        public string CommodityName { get; set; } = string.Empty;
        public string OfferFrequency { get; set; } = string.Empty; // مثال: "۵ بار در ۹۰ روز"
        public string AverageOfferVolume { get; set; } = string.Empty; // مثال: "۱,۵۰۰ تن"
        public double SuccessRate { get; set; } // درصد بین ۰ تا ۱۰۰
        public string SellThroughStatus { get; set; } = string.Empty; // مثال: "معمولا تمام می‌شود"
        public double AverageCompetition { get; set; } // درصد رقابت
        public string CompetitorPriceComparison { get; set; } = string.Empty; // مثال: "۲٪ گران‌تر از رقبا"
        public PriceComparisonStatus CompetitorPriceStatus { get; set; }
    }

    /// <summary>
    /// وضعیت قیمت یک کالا در مقایسه با رقبا
    /// </summary>
    public enum PriceComparisonStatus
    {
        Higher,
        Lower,
        Similar,
        NotApplicable // وقتی داده‌ای برای مقایسه وجود ندارد
    }
}
