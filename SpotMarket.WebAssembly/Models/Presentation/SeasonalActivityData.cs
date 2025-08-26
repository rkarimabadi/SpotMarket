namespace SpotMarket.WebAssembly.Models.Presentation
{
    public class SeasonalActivityData
    {
        public List<SeasonActivityItem> SeasonActivities { get; set; } = new();
        public string PeakSeasonName { get; set; } = string.Empty; // e.g., "تابستان"
    }

    public class SeasonActivityItem
    {
        public string SeasonName { get; set; } = string.Empty; // "بهار", "تابستان", "پاییز", "زمستان"
        public int OfferCount { get; set; }
        public double ActivityLevel { get; set; } // Normalized value from 0.0 to 1.0
    }
}
