namespace SpotMarket.WebAssembly.Models.Presentation
{
    public class SentimentItem
    {
        public string Name { get; set; } = string.Empty;
        public int Percentage { get; set; }
        public string ColorCssVariable { get; set; } = "var(--gray-400)";
    }

    public class MarketSentimentData
    {
        public List<SentimentItem> Items { get; set; } = new();
    }
}
