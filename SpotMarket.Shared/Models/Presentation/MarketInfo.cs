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
}
