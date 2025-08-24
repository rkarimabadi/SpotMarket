namespace SpotMarket.WebAssembly.Models.Presentation
{
    public class TopSuppliersData
    {
        public List<SupplierPerformanceItem> ByValue { get; set; }
        public List<SupplierPerformanceItem> ByVolume { get; set; }
        public List<SupplierPerformanceItem> ByCount { get; set; }
    }
    public class SupplierPerformanceItem
    {
        public string SupplierName { get; set; } = "";
        public int SupplierId { get; set; }
        public double Value { get; set; }
        public string DisplayValue { get; set; } = "";
    }
}
