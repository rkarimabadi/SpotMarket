using System.Text.Json.Serialization;

namespace SpotMarket.Shared.Models.Presentation
{
    /// <summary>
    /// نمایانگر یک کارت در ویجت تالارهای معاملاتی است
    /// </summary>
    public class TradingHallItem
    {
        public int Id { get; set; }
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
           /// <summary>
    /// وضعیت معامله یک عرضه را مشخص می‌کند.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OfferTradeStatus
    {
        /// <summary>
        /// معامله شده
        /// </summary>
        Traded,

        /// <summary>
        /// معامله نشد (وارد رقابت شد ولی فروش نرفت)
        /// </summary>
        Failed,

        /// <summary>
        /// معامله نشده (در انتظار عرضه)
        /// </summary>
        Untraded
    }

    /// <summary>
    /// مدل داده برای نمایش یک آیتم عرضه در لیست‌های تالار معاملات.
    /// </summary>
    public class OfferListItem
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string CommodityName { get; set; }
        public string SupplierName { get; set; }
        public decimal OfferVolume { get; set; }
        public decimal BasePrice { get; set; }
        public string Unit { get; set; } = "تن";
        public string PriceUnit { get; set; } = "ریال";
        public OfferTradeStatus Status { get; set; }

        /// <summary>
        /// شامل جزئیات معامله برای عرضه‌هایی که فرآیند معامله را طی کرده‌اند (موفق یا ناموفق).
        /// برای عرضه‌های در انتظار (Untraded)، این مقدار null خواهد بود.
        /// </summary>
        public OfferTradeDetails? TradeDetails { get; set; }
    }

    /// <summary>
    /// جزئیات آماری معامله یک عرضه.
    /// </summary>
    public class OfferTradeDetails
    {
        public decimal TradeVolume { get; set; }
        public decimal DemandVolume { get; set; }
        public decimal FinalPrice { get; set; }

        /// <summary>
        /// درصد رقابت (تفاوت قیمت پایانی با قیمت پایه)
        /// </summary>
        public double? CompetitionPercentage { get; set; }

        /// <summary>
        /// نسبت تقاضا به عرضه
        /// </summary>
        public double? DemandToOfferRatio { get; set; }

        /// <summary>
        /// آخرین وضعیت ثبت شده در تابلوی معاملات
        /// </summary>
        public string? TradeStepDescription { get; set; }
    }
}
