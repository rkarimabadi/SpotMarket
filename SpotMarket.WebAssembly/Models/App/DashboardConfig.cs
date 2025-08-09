namespace SpotMarket.WebAssembly.Models.App
{
    /// <summary>
    /// انواع ویجت‌های موجود در داشبورد را مشخص می‌کند
    /// </summary>
    public enum DashboardWidgetType
    {
        MarketProgress,
        TradingHalls,
        MarketMovers,
        MainPlayers,
        MarketExcitement,
        MarketPulse,
        MarketSentiment,
        SupplyRisk,
        News
    }

    /// <summary>
    /// تنظیمات مربوط به هر ویجت در داشبورد را نگه می‌دارد
    /// </summary>
    public class DashboardWidgetConfig
    {
        public DashboardWidgetType Type { get; set; }
        public bool IsVisible { get; set; } = true;
        public string GetDisplayName() => Type switch
        {
            DashboardWidgetType.MarketProgress => "پیشرفت بازار",
            DashboardWidgetType.TradingHalls => "سلامت تالارها",
            DashboardWidgetType.MarketMovers => "پویایی بازار",
            DashboardWidgetType.MainPlayers => "بازیگران اصلی",
            DashboardWidgetType.MarketExcitement => "سطح هیجان بازار",
            DashboardWidgetType.MarketPulse => "نبض بازار",
            DashboardWidgetType.MarketSentiment => "احساسات بازار",
            DashboardWidgetType.SupplyRisk => "ریسک تمرکز عرضه",
            DashboardWidgetType.News => "آخرین اخبار",
            _ => "ویجت ناشناس"
        };
    }

}
