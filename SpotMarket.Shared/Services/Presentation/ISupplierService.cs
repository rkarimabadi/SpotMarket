using SpotMarket.Shared.Models.Presentation;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface ISupplierService
    {
        Task<SupplierHeaderData?> GetSupplierHeaderAsync(int supplierId, CancellationToken ct = default);
        Task<List<HierarchyItem>?> GetSupplierHierarchyAsync(int supplierId, CancellationToken ct = default);
        Task<List<RankingItem>?> GetSupplierRankingAsync(int supplierId, CancellationToken ct = default);
        Task<IEnumerable<MainPlayer>?> GetMainPlayersAsync(int supplierId, CancellationToken ct = default);
        Task<List<CommodityGroupShareItem>?> GetMarketShareAsync(int supplierId, CancellationToken ct = default);
        Task<CompetitionData?> GetCompetitionRatioAsync(int supplierId, CancellationToken ct = default);
        Task<SeasonalActivityData?> GetSeasonalActivityAsync(int supplierId, CancellationToken ct = default);
        Task<MarketMetricData?> GetMarketMetricAsync(int supplierId, CancellationToken ct = default);
        Task<SupplierCommodityAnalysisData?> GetSupplierCommodityAnalysisAsync(int supplierId, CancellationToken ct = default);
        Task<UpcomingOffersData?> GetSupplierOffersAsync(int supplierId, CancellationToken ct = default);
        Task<List<SupplierItem>?> GetAllBrokersAsync(int supplierId, CancellationToken ct = default);
    }
}
