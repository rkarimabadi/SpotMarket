namespace SpotMarket.Shared.Models.Presentation
{
    public class MarketExcitementData
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Percentage { get; set; }
        public string Label { get; set; } = string.Empty;
        public string? EffectiveDate { get; set; }
        public bool IsForToday { get; set; }
    }
    public class ExcitementStat
    {
        public decimal InitPrice { get; set; }
        public decimal OfferVol { get; set; }
        public decimal InitVolume { get; set; }
        public decimal FinalPriceSum { get; set; }
        public decimal TradeVolumeSum { get; set; }
        public decimal DemandVolumeSum { get; set; }
    }

}
