namespace SpotMarket.WebAssembly.Models.App
{
    /// <summary>
    /// انواع نمای اصلی برای صفحه بازارها را تعریف می‌کند
    /// </summary>
    public enum MarketMainViewType
    {
        List,
        Heatmap,
        Shortcuts
    }

    /// <summary>
    /// ویجت‌های اطلاعاتی موجود در صفحه بازارها را تعریف می‌کند
    /// </summary>
    public enum MarketInfoWidgetType
    {
        ProgressRings,
        SelectedCommodity,
        TodayGroups
    }

    /// <summary>
    /// تنظیمات چیدمان صفحه بازارها را نگهداری می‌کند
    /// </summary>
    public class MarketSettings
    {
        public MarketMainViewType MainView { get; set; } = MarketMainViewType.List;
        public List<MarketInfoWidgetType> VisibleInfoWidgets { get; set; } = new();

        public string GetDisplayName(MarketMainViewType type) => type switch
        {
            MarketMainViewType.List => "لیست بازارها",
            MarketMainViewType.Heatmap => "نقشه حرارتی بازار",
            MarketMainViewType.Shortcuts => "میان‌برها",
            _ => "نمای ناشناس"
        };

        public string GetDisplayName(MarketInfoWidgetType type) => type switch
        {
            MarketInfoWidgetType.ProgressRings => "علائم حیاتی بازار",
            MarketInfoWidgetType.SelectedCommodity => "کالاهای پرطرفدار",
            MarketInfoWidgetType.TodayGroups => "گروه‌های منتخب",
            _ => "ویجت ناشناس"
        };
    }

    /// <summary>
    /// یک کلاس کمکی برای مدیریت وضعیت نمایش ویجت‌های اطلاعاتی در صفحه تنظیمات
    /// </summary>
    public class MarketInfoWidgetConfig
    {
        public MarketInfoWidgetType Type { get; set; }
        public bool IsVisible { get; set; }
        public required string DisplayName { get; set; }
    }
}
