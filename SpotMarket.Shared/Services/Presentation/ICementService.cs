using SpotMarket.Shared.Models.Presentation;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface ICementService
    {
        Task<CementGroupsData> GetCementGroupsDataAsync(CancellationToken ct = default);
        Task<CementMarketSummary> GetCementMarketSummaryDataAsync(CancellationToken ct = default);
        Task<BasicCementMarketSummary> GetBasicCementMarketSummaryDataAsync(CancellationToken ct = default);
        Task<CementQuickPathData> GetCementQuickPathDataAsync(CancellationToken ct = default);
        Task<QuickPathPageData> GetQuickPathPageDataAsync(string urlName, CancellationToken ct = default);
    }
}
