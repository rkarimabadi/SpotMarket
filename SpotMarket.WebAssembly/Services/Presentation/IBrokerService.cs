using SpotMarket.WebAssembly.Models.Presentation; // Assuming models are in this namespace
using static SpotMarket.WebAssembly.Pages.Broker.BrokerageCommodityGroupWidget;
using static SpotMarket.WebAssembly.Pages.Broker.BrokerageCompetitionWidget;
using static SpotMarket.WebAssembly.Pages.Broker.BrokerageRankingWidget;
using static SpotMarket.WebAssembly.Pages.Broker.BrokerageStrategicPerformanceWidget;

namespace SpotMarket.WebAssembly.Services.Presentation
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