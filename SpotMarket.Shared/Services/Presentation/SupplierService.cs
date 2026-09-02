using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;

namespace SpotMarket.Shared.Services.Presentation
{
    public class SupplierService : ISupplierService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/Supplier";

        public SupplierService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SupplierHeaderData?> GetSupplierHeaderAsync(int supplierId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<SupplierHeaderData>($"{_controllerPath}/{supplierId}/header", ct);
        }

        public async Task<List<HierarchyItem>?> GetSupplierHierarchyAsync(int supplierId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<HierarchyItem>>($"{_controllerPath}/{supplierId}/hierarchy", ct);
        }

        public async Task<List<RankingItem>?> GetSupplierRankingAsync(int supplierId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<RankingItem>>($"{_controllerPath}/{supplierId}/ranking", ct);
        }
        public async Task<IEnumerable<MainPlayer>?> GetMainPlayersAsync(int supplierId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MainPlayer>>($"{_controllerPath}/{supplierId}/main-players", ct);
        }
        public async Task<List<CommodityGroupShareItem>?> GetMarketShareAsync(int supplierId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<CommodityGroupShareItem>>($"{_controllerPath}/{supplierId}/market-share", ct);
        }
        public async Task<CompetitionData?> GetCompetitionRatioAsync(int supplierId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<CompetitionData>($"{_controllerPath}/{supplierId}/competition-ratio", ct);
        }
        public async Task<MarketMetricData?> GetMarketMetricAsync(int supplierId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<MarketMetricData>($"{_controllerPath}/{supplierId}/market-metric", ct);
        }
        public async Task<SupplierCommodityAnalysisData?> GetSupplierCommodityAnalysisAsync(int supplierId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<SupplierCommodityAnalysisData>($"{_controllerPath}/{supplierId}/commodity-analysis", ct);
        }

        public async Task<SeasonalActivityData?> GetSeasonalActivityAsync(int supplierId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<SeasonalActivityData?>($"{_controllerPath}/{supplierId}/seasonal-activity", ct) ?? new SeasonalActivityData();
        }
        public async Task<UpcomingOffersData?> GetSupplierOffersAsync(int supplierId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<UpcomingOffersData>($"{_controllerPath}/{supplierId}/offers", ct);
        }
        public async Task<List<SupplierItem>?> GetAllBrokersAsync(int supplierId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<SupplierItem>>($"{_controllerPath}/{supplierId}/all-brokers", ct);
        }
    }
}
