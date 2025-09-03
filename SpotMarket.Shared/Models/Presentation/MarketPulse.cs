namespace SpotMarket.Shared.Models.Presentation
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
        public string? EffectiveDate { get; set; }
        public bool IsForToday { get; set; }
    }
    public class MarketMetricData
    {
        public List<MarketPulseMetric> Metrics { get; set; } = new();
    }
    public class MarketPulseMetric
    {
        /// <summary>
        /// عنوان اصلی کارت. مثال: "نرخ موفقیت کل"
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// مقدار اصلی که به صورت بزرگ نمایش داده می‌شود. مثال: "۹۸٪"
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// توضیح تکمیلی در پایین کارت. مثال: "میانگین حجم فروش"
        /// </summary>
        public string Subtitle { get; set; } = string.Empty;

        /// <summary>
        /// کلاس CSS آیکون بوت‌استرپ. مثال: "bi bi-check-circle-fill"
        /// </summary>
        public string IconCssClass { get; set; } = string.Empty;

        /// <summary>
        /// کلاس CSS برای اعمال تم رنگی به کارت. مثال: "theme-success"
        /// </summary>
        public string ThemeColorCssClass { get; set; } = string.Empty;
    }
}
