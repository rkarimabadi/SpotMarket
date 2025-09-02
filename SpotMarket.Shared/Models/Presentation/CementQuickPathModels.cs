namespace SpotMarket.Shared.Models.Presentation
{
    public class ActiveFilter
    {
        public string Title { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public string IconCssClass { get; set; } = string.Empty;
        public List<FilterOption> Options { get; set; } = [];
    }
    public class FilterOption
    {
        public string Title { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public bool IsSelected { get; set; }

        public FilterOption( string title, string key, string value, bool isSelected)
        {
            Title = title;
            Key = key;
            Value = value;
            IsSelected = isSelected;
        }
    }
    public record FilterChangeArgs(string FilterTitle, string SelectedKey);
    // مدل داده برای ویجت "مشخصات فنی"
    public class TechnicalSpecification
    {
        public string Title { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Interpretation { get; set; } = string.Empty;
        public string IconCssClass { get; set; } = string.Empty;
        public string ThemeCssClass { get; set; } = string.Empty;
    }

    // مدل داده برای ویجت "روند قیمت"
    public class PriceTrendData
    {
        public string Title { get; set; } = string.Empty;
        public List<PricePoint> PriceHistory { get; set; } = new();
    }

    public class PricePoint
    {
        public string DateLabel { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    // مدل داده برای ویجت "عرضه‌کنندگان اصلی"
    public class MainSupplier
    {
        public string SupplierName { get; set; } = string.Empty;
        public decimal LastTradePrice { get; set; }
        public decimal OfferedVolume { get; set; }
    }

    // مدل داده برای ویجت "عرضه‌های فعال و آتی"
    public class UpcomingOffer
    {
        public string Date { get; set; } = string.Empty;
        public string DayOfWeek { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public string Volume { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string UrlName { get; set; } = string.Empty;
    }

    // مدل جامع صفحه
    public class QuickPathPageData
    {
        public string PageTitle { get; set; } = string.Empty;
        public List<ActiveFilter> ActiveFilters { get; set; } = new();
        public List<TechnicalSpecification> Specifications { get; set; } = new();
        public PriceTrendData PriceTrend { get; set; } = new();
        public List<MainSupplier> MainSuppliers { get; set; } = new();
        public List<UpcomingOffer> UpcomingOffers { get; set; } = new();
    }

    public class CementQuickPathFilterData
    {
        public List<FilterOption> CementTypes { get; set; } = new();
        public List<FilterOption> Types { get; set; } = new();
        public List<FilterOption> Packaging { get; set; } = new();
        public List<FilterOption> Grades { get; set; } = new();
    }
}
