namespace SpotMarket.WebAssembly.Models.Presentation
{
    public class PriceViewModel
    {
        public decimal CurrentPrice { get; set; }
        public decimal ChangeAmount { get; set; }
        public double ChangePercentage { get; set; }
        public string ChangeContext { get; set; } = "";
        public string DateLabel { get; set; } = "";
        public bool IsOutdated { get; set; }
        public List<PriceHistoryPoint> PriceHistory { get; set; } = new();
        public List<HighlightViewModel> Highlights { get; set; } = new();
    }

    public class PriceHistoryPoint
    {
        public string DateLabel { get; set; } = "";
        public decimal Price { get; set; }
    }

    public class HighlightViewModel
    {
        public string Title { get; set; } = "";
        public string Value { get; set; } = "";
        public string Unit { get; set; } = "";
        public string IconSvg { get; set; } = "";
        public string IconColorClass { get; set; } = "";
    }
}
