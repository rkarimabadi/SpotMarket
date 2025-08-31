namespace SpotMarket.WebAssembly.Models.Presentation
{
    public class OfferViewModel
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CommodityName { get; set; } = string.Empty;
        public int CommodityId { get; set; }
        public string OfferRing { get; set; } = string.Empty;
        public List<HierarchyItem> HierarchyItems { get; set; } = new List<HierarchyItem>();
        public string ContractType { get; set; } = string.Empty;
        public string Supplier { get; set; } = string.Empty;
        public int SupplierId { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
        public string Broker { get; set; } = string.Empty;
        public int BrokerId { get; set; }
        public string OfferDate { get; set; } = string.Empty;
        public string DeliveryDate { get; set; } = string.Empty;
        public decimal InitialPrice { get; set; }
        public decimal OfferVolume { get; set; }
        public string MeasurementUnit { get; set; } = "تن";
        public string CurrencyUnit { get; set; } = "ریال";
        public decimal MinOrderVolume { get; set; }
        public decimal MaxOrderVolume { get; set; }
        public decimal WeightFactor { get; set; } // ضریب محموله
        public decimal LotSize { get; set; } // اندازه محموله
        public decimal PrepaymentPercent { get; set; }
        public decimal TickSize { get; set; }
        public string Description { get; set; } = string.Empty;
        public string OfferMode { get; set; } = string.Empty;
        public string DeliveryPlace { get; set; } = string.Empty;
        public string BuyMethod { get; set; } = string.Empty;
        public string OfferType { get; set; } = string.Empty;
        public string SettlementType { get; set; } = string.Empty;
        public string PackagingType { get; set; } = string.Empty;
        public string SecurityType { get; set; } = string.Empty;
    }
}
