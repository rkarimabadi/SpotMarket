namespace SpotMarket.WebAssembly.Models.Presentation
{
    public class StrategicPerformanceItem
    {
        public string CommodityName { get; set; } = "";
        public int CommodityId { get; set; }
        public PerformanceStatus ValuePerformance { get; set; }
        public PerformanceStatus VolumePerformance { get; set; }
    }

    public enum PerformanceStatus { Strong, Weak, NotPresent }
}
