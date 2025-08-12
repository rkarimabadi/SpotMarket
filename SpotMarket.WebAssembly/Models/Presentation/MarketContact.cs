using System.Collections.Generic;

namespace SpotMarket.WebAssembly.Models.Presentation
{
    /// <summary>
    /// نمایانگر یک آیتم در ویجت مخاطبین بازار است
    /// </summary>
    public class MarketContactItem
    {
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string IconCssClass { get; set; } = string.Empty;
        public string AvatarCssClass { get; set; } = string.Empty;
    }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت مخاطبین بازار
    /// </summary>
    public class MarketContactsData
    {
        public List<MarketContactItem> Items { get; set; } = new();
    }
}
