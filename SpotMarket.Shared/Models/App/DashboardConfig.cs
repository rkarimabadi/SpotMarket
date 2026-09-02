namespace SpotMarket.Shared.Models.App
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
        SpotNotifictions,

        // مقادیر این enum به‌صورت عددی در تنظیمات کاربر ذخیره می‌شود، پس موارد جدید
        // فقط باید به انتهای فهرست اضافه شوند تا چیدمان ذخیره‌شده جابه‌جا نشود.
        ChatAssistant
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
            DashboardWidgetType.SpotNotifictions => "آخرین اخبار",
            DashboardWidgetType.ChatAssistant => "دستیار بازار",
            _ => "ویجت ناشناس"
        };
    }

}
