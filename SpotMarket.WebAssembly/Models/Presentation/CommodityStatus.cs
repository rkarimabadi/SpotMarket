using System.Collections.Generic;

namespace SpotMarket.WebAssembly.Models.Presentation
{
    /// <summary>
    /// وضعیت تقاضا به عرضه را مشخص می‌کند
    /// </summary>
    public enum DemandStatus
    {
        Low,    // تقاضا کمتر از عرضه
        Medium, // تقاضا و عرضه متعادل
        High    // تقاضا بیشتر از عرضه
    }

    /// <summary>
    /// نمایانگر یک آیتم در لیست گروه‌های کالایی است
    /// </summary>
    public class CommodityStatusItem
    {
        public string Name { get; set; } = string.Empty;
        public string MainGroupName { get; set; } = string.Empty;
        public int OfferCount { get; set; }
        public DemandStatus DemandStatus { get; set; } = DemandStatus.Medium;
    }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت لیست گروه‌های کالایی
    /// </summary>
    public class CommodityStatusData
    {
        public List<CommodityStatusItem> Items { get; set; } = new();
    }
}
