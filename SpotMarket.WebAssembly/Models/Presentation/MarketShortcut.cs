using System.Collections.Generic;

namespace SpotMarket.WebAssembly.Models.Presentation
{
    /// <summary>
    /// نمایانگر یک آیتم در ویجت میان‌برها است
    /// </summary>
    public class MarketShortcutItem
    {
        public string Title { get; set; } = string.Empty;
        public string IconCssClass { get; set; } = string.Empty;
        public string ThemeCssClass { get; set; } = string.Empty;
    }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت میان‌برها
    /// </summary>
    public class MarketShortcutsData
    {
        public List<MarketShortcutItem> Items { get; set; } = new();
    }
}
