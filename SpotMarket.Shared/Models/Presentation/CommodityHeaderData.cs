namespace SpotMarket.Shared.Models.Presentation
{
    public class CommodityHeaderData
    {
        public string CommodityName { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string Ring { get; set; } = string.Empty;
        public List<HierarchyItem> Hierarchy { get; set; } = new List<HierarchyItem>();
    }
}
