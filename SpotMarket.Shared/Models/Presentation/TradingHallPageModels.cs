using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMarket.Shared.Models.Presentation
{
    public record TradingHallHeaderData(string Title, string Subtitle);

    // 1. Model for the Status Widget
    public enum HallStatus { Closed, PreOpening, Open, Continuous }

    public class HallStatusData
    {
        // Offer Statistics
        public int TotalOffers { get; set; }
        public int TradedOffers { get; set; }
        public int InTradingOffers { get; set; }
        public int RemainingOffers => TotalOffers - TradedOffers - InTradingOffers;

        // Hall Timings & Status
        public HallStatus Status { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

    // 2. Models for the "Trades" Tab
    public enum PerformanceState { Improved, Worsened, Neutral }

    public class HallPerformanceItem
    {
        public string Title { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string ChangeDescription { get; set; } = string.Empty;
        public PerformanceState State { get; set; }
    }

    // Models for the Daily Highlights Widget 
    public record HighlightItem(
        string CommodityName,
        string FormattedValue,
        string? Description = null);

    public class DailyHighlightsData
    {
        public List<HighlightItem> TopValueTrades { get; set; } = new();
        public List<HighlightItem> HottestCompetitions { get; set; } = new();
        public List<HighlightItem> HeaviestCompetitions { get; set; } = new();
    }
}
