namespace SpotMarket.Shared.Models.Presentation
{
    public record TradeBoardMarketStepView
    {
        public int MarketId { get; set; }

        public double Duration { get; set; }

        public int Counter { get; set; }

        public string Color { get; set; } = string.Empty;

        public string StepDescription { get; set; } = string.Empty;

        public string StartTime { get; set; } = string.Empty;

        public string FinishTime { get; set; } = string.Empty;

        public int? ActiveInstrumentId { get; set; }

        public string MarketName { get; set; } = string.Empty;

        public int Status { get; set; }

        public bool IsDeleted { get; set; }
    }
}
