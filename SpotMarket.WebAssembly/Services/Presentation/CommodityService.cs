using SpotMarket.WebAssembly.Models.Presentation;
using System.Net.Http.Json;

namespace SpotMarket.WebAssembly.Services.Presentation
{
    public interface ICommodityService
    {
        Task<CommodityHeaderData?> GetCommodityHeaderAsync(int commodityId);
        Task<PriceViewModel?> GetPriceTrendsAsync(int commodityId);
        Task<MarketAbsorptionData?> GetMarketAbsorptionAsync(int commodityId);
        Task<CommodityAttributesData?> GetCommodityAttributesAsync(int commodityId);
        Task<IEnumerable<MainPlayer>?> GetMainPlayersAsync(int commodityId);
        Task<DistributedAttributesData?> GetDistributedAttributesAsync(int commodityId);
    }

        public class CommodityService : ICommodityService
        {
            private readonly HttpClient _httpClient;
            private readonly string _controllerPath = "/api/Commodity";

            public CommodityService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            public async Task<CommodityHeaderData?> GetCommodityHeaderAsync(int commodityId)
            {
                return await _httpClient.GetFromJsonAsync<CommodityHeaderData>($"{_controllerPath}/{commodityId}/header");
            }
    
            public async Task<PriceViewModel?> GetPriceTrendsAsync(int commodityId)
            {
                return await _httpClient.GetFromJsonAsync<PriceViewModel>($"{_controllerPath}/{commodityId}/price-trends");
            }

            public async Task<MarketAbsorptionData?> GetMarketAbsorptionAsync(int commodityId)
            {
                return await _httpClient.GetFromJsonAsync<MarketAbsorptionData>($"{_controllerPath}/{commodityId}/market-absorption");
            }

            public async Task<CommodityAttributesData?> GetCommodityAttributesAsync(int commodityId)
            {
                return await _httpClient.GetFromJsonAsync<CommodityAttributesData>($"{_controllerPath}/{commodityId}/attributes");
            }

            public async Task<IEnumerable<MainPlayer>?> GetMainPlayersAsync(int commodityId)
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<MainPlayer>>($"{_controllerPath}/{commodityId}/main-players");
            }

            public async Task<DistributedAttributesData?> GetDistributedAttributesAsync(int commodityId)
            {
                return await _httpClient.GetFromJsonAsync<DistributedAttributesData>($"{_controllerPath}/{commodityId}/distributed-attributes");
            }
        }
}
