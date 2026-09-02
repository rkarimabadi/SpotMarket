using SpotMarket.Shared.Models.Presentation;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface IBrokerService
    {
        Task<BrokerHeaderData?> GetBrokerHeaderAsync(int brokerId, CancellationToken ct = default);
        Task<CompetitionData?> GetCompetitionRatioAsync(int brokerId, CancellationToken ct = default);
        Task<CompetitionData?> GetSuccessRateAsync(int brokerId, CancellationToken ct = default);
        Task<List<MarketShareItem>?> GetMarketShareAsync(int brokerId, CancellationToken ct = default);
        Task<List<RankingItem>?> GetRankingAsync(int brokerId, CancellationToken ct = default);
        Task<List<CommodityGroupShareItem>?> GetCommodityGroupShareAsync(int brokerId, CancellationToken ct = default);
        Task<UpcomingOffersData?> GetBrokerOffersAsync(int brokerId, CancellationToken ct = default);
        Task<TopSuppliersData?> GetTopSuppliersAsync(int brokerId, CancellationToken ct = default);
        Task<List<SupplierItem>?> GetAllSuppliersAsync(int brokerId, CancellationToken ct = default);
        Task<List<StrategicPerformanceItem>?> GetStrategicPerformanceAsync(int brokerId, CancellationToken ct = default);
    }
}
