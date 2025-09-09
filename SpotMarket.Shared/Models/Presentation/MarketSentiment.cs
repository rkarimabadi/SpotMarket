namespace SpotMarket.Shared.Models.Presentation
{
    public class SentimentItem
    {
        public string Name { get; set; } = string.Empty;
        public int Percentage { get; set; }
        public string ColorCssVariable { get; set; } = "var(--gray-400)";
    }

    public class MarketSentimentData
    {
        public IEnumerable<SentimentItem> Items { get; set; } = Enumerable.Empty<SentimentItem>();
        public string? EffectiveDate { get; set; }
        public bool IsForToday { get; set; }
    }
}
