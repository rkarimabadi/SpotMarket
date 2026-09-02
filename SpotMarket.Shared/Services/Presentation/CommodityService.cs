using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface ICommodityService
    {
        Task<CommodityHeaderData?> GetCommodityHeaderAsync(int commodityId, CancellationToken ct = default);
        Task<PriceViewModel?> GetPriceTrendsAsync(int commodityId, CancellationToken ct = default);
        Task<MarketAbsorptionData?> GetMarketAbsorptionAsync(int commodityId, CancellationToken ct = default);
        Task<CommodityAttributesData?> GetCommodityAttributesAsync(int commodityId, CancellationToken ct = default);
        Task<IEnumerable<MainPlayer>?> GetMainPlayersAsync(int commodityId, CancellationToken ct = default);
        Task<DistributedAttributesData?> GetDistributedAttributesAsync(int commodityId, CancellationToken ct = default);
        Task<List<HierarchyItem>> GetCommodityHierarchyAsync(int commodityId, CancellationToken ct = default);
        Task<UpcomingOffersData?> GetOfferHistoryAsync(int commodityId, CancellationToken ct = default);
        Task<DistributedAttributesData> GetPlayerDistributionAsync(int commodityId, CancellationToken ct = default);
    }

        public class CommodityService : ICommodityService
        {
            private readonly HttpClient _httpClient;
            private readonly string _controllerPath = "/api/Commodity";

            public CommodityService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public async Task<CommodityHeaderData?> GetCommodityHeaderAsync(int commodityId, CancellationToken ct = default)
            {
                return await _httpClient.GetFromJsonAsync<CommodityHeaderData>($"{_controllerPath}/{commodityId}/header", ct);
            }
    
            public async Task<PriceViewModel?> GetPriceTrendsAsync(int commodityId, CancellationToken ct = default)
            {
                return await _httpClient.GetFromJsonAsync<PriceViewModel>($"{_controllerPath}/{commodityId}/price-trends", ct);
            }
            public async Task<List<HierarchyItem>> GetCommodityHierarchyAsync(int commodityId, CancellationToken ct = default)
            {
                return await _httpClient.GetFromJsonAsync<List<HierarchyItem>>($"{_controllerPath}/{commodityId}/hierarchy", ct);
            }

            public async Task<MarketAbsorptionData?> GetMarketAbsorptionAsync(int commodityId, CancellationToken ct = default)
            {
                return await _httpClient.GetFromJsonAsync<MarketAbsorptionData>($"{_controllerPath}/{commodityId}/market-absorption", ct);
            }

            public async Task<CommodityAttributesData?> GetCommodityAttributesAsync(int commodityId, CancellationToken ct = default)
            {
                return await _httpClient.GetFromJsonAsync<CommodityAttributesData>($"{_controllerPath}/{commodityId}/attributes", ct);
            }

            public async Task<IEnumerable<MainPlayer>?> GetMainPlayersAsync(int commodityId, CancellationToken ct = default)
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<MainPlayer>>($"{_controllerPath}/{commodityId}/main-players", ct);
            }

            public async Task<DistributedAttributesData?> GetDistributedAttributesAsync(int commodityId, CancellationToken ct = default)
            {
                return await _httpClient.GetFromJsonAsync<DistributedAttributesData>($"{_controllerPath}/{commodityId}/distributed-attributes", ct);
            }

            public async Task<DistributedAttributesData?> GetPlayerDistributionAsync(int commodityId, CancellationToken ct = default)
            {
                return await _httpClient.GetFromJsonAsync<DistributedAttributesData>($"{_controllerPath}/{commodityId}/player-distribution", ct);
            }
            public async Task<UpcomingOffersData?> GetOfferHistoryAsync(int commodityId, CancellationToken ct = default)
        {
                return await _httpClient.GetFromJsonAsync<UpcomingOffersData>($"{_controllerPath}/{commodityId}/offer-history", ct);
            }
        }
}
