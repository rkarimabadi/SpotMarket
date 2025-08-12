namespace SpotMarket.WebAssembly.Models.Presentation
{
    /// <summary>
    /// دسته‌بندی‌های مختلف اخبار را مشخص می‌کند
    /// </summary>
    public enum SpotNotificationCategory
    {
        Announcement, // ابلاغیه
        Amendment, // اصلاحیه
        ProductAcceptance, // پذیرش کالا
        CarAcceptance, // پذیرش خودرو
        LicenseRenewal, // تمدید مجوز
        Other // سایر
    }

    /// <summary>
    /// نمایانگر یک آیتم خبری در لیست است
    /// </summary>
    public class SpotNotificationItem
    {
        public string Title { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public SpotNotificationCategory Category { get; set; }
    }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت اخبار
    /// </summary>
    public class SpotNotificationData
    {
        public string ActionText { get; set; } = "بیشتر";
        public string ActionLink { get; set; } = "/spot-notifications";
        public List<SpotNotificationItem> Items { get; set; } = new();
    }
}
