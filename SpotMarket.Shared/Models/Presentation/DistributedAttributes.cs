using System.Collections.Generic;

namespace SpotMarket.Shared.Models.Presentation
{
    /// <summary>
    /// نمایانگر سهم یک مقدار خاص از یک ویژگی است
    /// </summary>
    public class AttributeValueShare
    {
        public string Name { get; set; } = string.Empty;
        public double Percentage { get; set; }
        public string ColorCssClass { get; set; } = string.Empty;
    }

    /// <summary>
    /// نمایانگر یک ویژگی با مقادیر توزیع شده است
    /// </summary>
    public class DistributedAttributeItem
    {
        public string Title { get; set; } = string.Empty;
        public string IconCssClass { get; set; } = string.Empty;
        public string IconBgCssClass { get; set; } = string.Empty;
        public List<AttributeValueShare> ValueDistribution { get; set; } = new();
        public string Interpretation { get; set; } = string.Empty;
        public bool IsAlert { get; set; }
        public string? DominantValue { get; set; }
        public string? MarketMostCommonValue { get; set; }
    }

    /// <summary>
    /// نگهدارنده کل داده‌های مورد نیاز برای ویجت
    /// </summary>
    public class DistributedAttributesData
    {
        public List<DistributedAttributeItem> Items { get; set; } = new();
    }
}
