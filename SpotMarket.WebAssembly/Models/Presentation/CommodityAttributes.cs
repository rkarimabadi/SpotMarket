using System.Collections.Generic;

namespace SpotMarket.WebAssembly.Models.Presentation
{
    /// <summary>
    /// نمایانگر یک ویژگی (Attribute) از یک کالا است
    /// </summary>
    public class CommodityAttributeItem
    {
        public string Title { get; set; } = string.Empty;
        public string IconCssClass { get; set; } = string.Empty;
        public string IconBgCssClass { get; set; } = string.Empty;

        /// <summary>
        /// مقدار فعلی ویژگی برای این کالا
        /// </summary>
        public string CurrentValue { get; set; } = string.Empty;

        /// <summary>
        /// تفسیر و توضیح معنی این ویژگی در بازار
        /// </summary>
        public string Interpretation { get; set; } = string.Empty;

        /// <summary>
        /// مشخص می‌کند که آیا این ویژگی یک ناهنجاری یا هشدار است یا خیر
        /// </summary>
        public bool IsAlert { get; set; }

        /// <summary>
        /// در صورت هشدار، فراوان‌ترین مقدار برای خود کالا را نمایش می‌دهد
        /// </summary>
        public string? CommodityMostCommonValue { get; set; }

        /// <summary>
        /// در صورت هشدار، فراوان‌ترین مقدار در کل بازار را نمایش می‌دهد
        /// </summary>
        public string? MarketMostCommonValue { get; set; }
    }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت ویژگی‌های کالا
    /// </summary>
    public class CommodityAttributesData
    {
        public List<CommodityAttributeItem> Items { get; set; } = new();
    }
}
