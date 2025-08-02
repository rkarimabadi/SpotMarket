namespace SpotMarket.WebAssembly.Models.App
{
    /// <summary>
    /// انواع ویجت‌های موجود در داشبورد را مشخص می‌کند
    /// </summary>
    public enum DashboardWidgetType
    {
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
    }
}
