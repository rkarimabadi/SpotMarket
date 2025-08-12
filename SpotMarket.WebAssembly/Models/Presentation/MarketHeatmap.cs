using System.Collections.Generic;

namespace SpotMarket.WebAssembly.Models.Presentation
{
    /// <summary>
    /// رتبه‌بندی حرارت بازار را مشخص می‌کند
    /// </summary>
    public enum MarketHeatRank
    {
        High,
        Medium,
        Low,
        Neutral
    }

    /// <summary>
    /// نمایانگر یک آیتم در نقشه حرارتی بازار است
    /// </summary>
    public class MarketHeatmapItem
    {
        public string Title { get; set; } = string.Empty;
        public string? Subtitle { get; set; } // برای نمایش در کارت‌های بزرگ
        public string? Value { get; set; } // برای نمایش در کارت‌های بزرگ
        public MarketHeatRank Rank { get; set; }
    }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت نقشه حرارتی
    /// </summary>
    public class MarketHeatmapData
    {
        public List<MarketHeatmapItem> Items { get; set; } = new();
    }
}
