using SpotMarket.Shared.Models.Presentation;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface IBrokerService
    {
        Task<BrokerHeaderData?> GetBrokerHeaderAsync(int brokerId);
        Task<CompetitionData?> GetCompetitionRatioAsync(int brokerId);
        Task<CompetitionData?> GetSuccessRateAsync(int brokerId);
        Task<List<MarketShareItem>?> GetMarketShareAsync(int brokerId);
        Task<List<RankingItem>?> GetRankingAsync(int brokerId);
        Task<List<CommodityGroupShareItem>?> GetCommodityGroupShareAsync(int brokerId);
        Task<UpcomingOffersData?> GetBrokerOffersAsync(int brokerId);
        Task<TopSuppliersData?> GetTopSuppliersAsync(int brokerId);
        Task<List<SupplierItem>?> GetAllSuppliersAsync(int brokerId);
        Task<List<StrategicPerformanceItem>?> GetStrategicPerformanceAsync(int brokerId);
    }
}