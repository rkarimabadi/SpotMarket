using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;


namespace SpotMarket.Shared.Services.Presentation
{
    public class BrokerService : IBrokerService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/Broker";

        public BrokerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BrokerHeaderData?> GetBrokerHeaderAsync(int brokerId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<BrokerHeaderData>($"{_controllerPath}/{brokerId}/header", ct);
        }

        public async Task<CompetitionData?> GetCompetitionRatioAsync(int brokerId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<CompetitionData>($"{_controllerPath}/{brokerId}/competition-ratio", ct);
        }

        public async Task<CompetitionData?> GetSuccessRateAsync(int brokerId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<CompetitionData>($"{_controllerPath}/{brokerId}/success-rate", ct);
        }

        public async Task<List<MarketShareItem>?> GetMarketShareAsync(int brokerId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<MarketShareItem>>($"{_controllerPath}/{brokerId}/market-share", ct);
        }

        public async Task<List<RankingItem>?> GetRankingAsync(int brokerId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<RankingItem>>($"{_controllerPath}/{brokerId}/ranking", ct);
        }

        public async Task<List<CommodityGroupShareItem>?> GetCommodityGroupShareAsync(int brokerId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<CommodityGroupShareItem>>($"{_controllerPath}/{brokerId}/commodity-group-share", ct);
        }

        public async Task<UpcomingOffersData?> GetBrokerOffersAsync(int brokerId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<UpcomingOffersData>($"{_controllerPath}/{brokerId}/offers", ct);
        }
        public async Task<List<SupplierItem>?> GetAllSuppliersAsync(int brokerId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<SupplierItem>>($"{_controllerPath}/{brokerId}/all-suppliers", ct);
        }

        public async Task<TopSuppliersData?> GetTopSuppliersAsync(int brokerId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<TopSuppliersData>($"{_controllerPath}/{brokerId}/top-suppliers", ct);
        }


        public async Task<List<StrategicPerformanceItem>?> GetStrategicPerformanceAsync(int brokerId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<StrategicPerformanceItem>>($"{_controllerPath}/{brokerId}/strategic-performance", ct);
        }
    }
}
