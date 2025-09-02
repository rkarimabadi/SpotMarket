using SpotMarket.Shared.Models.Presentation;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface ICementService
    {
        Task<CementGroupsData> GetCementGroupsDataAsync();
        Task<CementMarketSummary> GetCementMarketSummaryDataAsync();
        Task<BasicCementMarketSummary> GetBasicCementMarketSummaryDataAsync();
        Task<CementQuickPathData> GetCementQuickPathDataAsync();
    }
}