using SpotMarket.WebAssembly.Models.Presentation;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static SpotMarket.WebAssembly.Pages.Broker.BrokerageCommodityGroupWidget;
using static SpotMarket.WebAssembly.Pages.Broker.BrokerageCompetitionWidget;
using static SpotMarket.WebAssembly.Pages.Broker.BrokerageRankingWidget;
using static SpotMarket.WebAssembly.Pages.Broker.BrokerageStrategicPerformanceWidget;

namespace SpotMarket.WebAssembly.Services.Presentation
{
    public class BrokerService : IBrokerService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/Broker";

        public BrokerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BrokerHeaderData?> GetBrokerHeaderAsync(int brokerId)
        {
            return await _httpClient.GetFromJsonAsync<BrokerHeaderData>($"{_controllerPath}/{brokerId}/header");
        }

        public async Task<CompetitionData?> GetCompetitionRatioAsync(int brokerId)
        {
            return await _httpClient.GetFromJsonAsync<CompetitionData>($"{_controllerPath}/{brokerId}/competition-ratio");
        }

        public async Task<CompetitionData?> GetSuccessRateAsync(int brokerId)
        {
            return await _httpClient.GetFromJsonAsync<CompetitionData>($"{_controllerPath}/{brokerId}/success-rate");
        }

        public async Task<List<MarketShareItem>?> GetMarketShareAsync(int brokerId)
        {
            return await _httpClient.GetFromJsonAsync<List<MarketShareItem>>($"{_controllerPath}/{brokerId}/market-share");
        }

        public async Task<List<RankingItem>?> GetRankingAsync(int brokerId)
        {
            return await _httpClient.GetFromJsonAsync<List<RankingItem>>($"{_controllerPath}/{brokerId}/ranking");
        }

        public async Task<List<CommodityGroupShareItem>?> GetCommodityGroupShareAsync(int brokerId)
        {
            return await _httpClient.GetFromJsonAsync<List<CommodityGroupShareItem>>($"{_controllerPath}/{brokerId}/commodity-group-share");
        }

        public async Task<UpcomingOffersData?> GetBrokerOffersAsync(int brokerId)
        {
            return await _httpClient.GetFromJsonAsync<UpcomingOffersData>($"{_controllerPath}/{brokerId}/offers");
        }
        public async Task<List<SupplierItem>?> GetAllSuppliersAsync(int brokerId)
        {
            return await _httpClient.GetFromJsonAsync<List<SupplierItem>>($"{_controllerPath}/{brokerId}/all-suppliers");
        }

        public async Task<TopSuppliersData?> GetTopSuppliersAsync(int brokerId)
        {
            return await _httpClient.GetFromJsonAsync<TopSuppliersData>($"{_controllerPath}/{brokerId}/top-suppliers");
        }


        public async Task<List<StrategicPerformanceItem>?> GetStrategicPerformanceAsync(int brokerId)
        {
            return await _httpClient.GetFromJsonAsync<List<StrategicPerformanceItem>>($"{_controllerPath}/{brokerId}/strategic-performance");
        }
    }
}