namespace SpotMarket.WebAssembly.Models.Presentation
{
    public record MarketActivity(
        string Title,
        string CssClass,
        double Percentage,
        string PrimaryMetric,
        string SecondaryMetric
    );
}
