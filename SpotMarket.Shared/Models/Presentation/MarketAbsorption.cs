namespace SpotMarket.Shared.Models.Presentation
{
    /// <summary>
    /// مدل داده برای ویجت نرخ جذب عرضه
    /// </summary>
    public class MarketAbsorptionData
    {
        public string Title { get; set; } = "نرخ جذب عرضه";
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// درصد حجم معامله شده به حجم عرضه شده (بین ۰ تا ۱۰۰)
        /// </summary>
        public int Percentage { get; set; }

        /// <summary>
        /// لیبل وضعیت (مثلا: بالا، پایین، متوسط)
        /// </summary>
        public string Label { get; set; } = string.Empty;
    }
}
