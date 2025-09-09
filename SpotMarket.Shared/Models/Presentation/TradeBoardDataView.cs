namespace SpotMarket.Shared.Models.Presentation
{
    public class TradeBoardDataView
    {
        public int InstrumentId { get; set; }
        
        public int? MarketId { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public string StartTime { get; set; } = string.Empty;
        
        public string FinishTime { get; set; } = string.Empty;
        
        public double Duration { get; set; }
        
        public int Counter { get; set; }
        
        public string Color { get; set; } = string.Empty;
        
        public string InstrumentName { get; set; } = string.Empty;
        
        public string InstrumentSymbol { get; set; } = string.Empty;
        
        public string Producer { get; set; } = string.Empty;
        
        public string Supplier { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string ContractKind { get; set; } = string.Empty;
        
        public string DeliveryPlace { get; set; } = string.Empty;
        
        public string DeliveryDate { get; set; } = string.Empty;
        
        public string SettleDate { get; set; } = string.Empty;
        
        public string Unit { get; set; } = string.Empty;
        
        public int? QtySell { get; set; } = 0;
        
        public string Currency { get; set; } = string.Empty;
        
        public decimal? CurrentSellPrice { get; set; } = 0;
        
        public int? TotalBuyQty { get; set; } = 0;
        
        public int? TotalReceptionBasePriceDemand { get; set; } = 0;
        
        public decimal? SumBuy1 { get; set; } = 0;
        
        public int? QtyBuy1 { get; set; } = 0;
        
        public decimal? SumBuy2 { get; set; } = 0;
        
        public int? QtyBuy2 { get; set; } = 0;
        
        public decimal? SumBuy3 { get; set; } = 0;
        
        public int? QtyBuy3 { get; set; } = 0;
        
        public decimal? SumBuy4 { get; set; } = 0;
        
        public int? QtyBuy4 { get; set; } = 0;
        
        public decimal? SumBuy5 { get; set; } = 0;
        
        public int? QtyBuy5 { get; set; } = 0;
        
        public int? Status { get; set; } = 0;
        
        public string StatusDesc { get; set; } = string.Empty;
        
        public int? TradeStatus { get; set; } = 0;
        
        public string TradeStatusDesc { get; set; } = string.Empty;
        
        public int? MatchOrdersQty { get; set; } = 0;
        
        public decimal? MatchOrdersPrice { get; set; } = 0;
        
        public decimal? LowestMatchedPrice { get; set; } = 0;
        
        public bool Activate { get; set; } = false;
        
        public bool IsDeleted { get; set; }
    }
}
