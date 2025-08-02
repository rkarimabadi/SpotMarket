namespace SpotMarket.WebAssembly.Models.App
{
    /// <summary>
    /// مدل اصلی برای نگهداری تمام تنظیمات کاربر
    /// </summary>
    public class UserSettings
    {
        public List<DashboardWidgetConfig> DashboardLayout { get; set; } = new();
    }

}
