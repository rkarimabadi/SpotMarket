using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SpotMarket.Shared.Models.Presentation
{
    public record MarketInfo(
        string Title,
        int Code,
        string Subtitle,
        string UrlName,
        string IconClass,
        string IconContainerClass,
        string HeatLevel,
        string HeatLabel
    );
    public class TradingMarketInfo
    {
        public int? MarketId { get; set; }

        public string MarketName { get; set; } = string.Empty;

        public string StartTime { get; set; } = string.Empty;

        public string FinishTime { get; set; } = string.Empty;

        public double Duration { get; set; }

        public int Counter { get; set; }

        public string Color { get; set; } = string.Empty;

        public string StepDescription { get; set; } = string.Empty;

        public int? Activate { get; set; }

        public int? Count { get; set; }

        public int Status { get; set; }
    }
}
