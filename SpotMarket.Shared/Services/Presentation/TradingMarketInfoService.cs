using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;

namespace SpotMarket.Shared.Services.Presentation
{
    public class TradingMarketInfoService : ITradingMarketInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/TradingMarketInfo";

        public TradingMarketInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TradingMarketInfo>> GetAllMarketsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TradingMarketInfo>>($"{_controllerPath}/all") ?? new List<TradingMarketInfo>();
        }
        public async Task<TradingHallHeaderData?> GetHeaderDataAsync(int marketId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<TradingHallHeaderData>($"{_controllerPath}/{marketId}/header");
            }
            catch
            {
                return new TradingHallHeaderData("تالار معاملات", "بورس کالا");
            }
        }

        public async Task<HallStatusData?> GetStatusDataAsync(int marketId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<HallStatusData>($"{_controllerPath}/{marketId}/status");
            }
            catch
            {
                return null;
            }
        }

        public async Task<DailyHighlightsData?> GetHighlightsDataAsync(int marketId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<DailyHighlightsData>($"{_controllerPath}/{marketId}/highlights");
            }
            catch
            {
                return new DailyHighlightsData();
            }
        }
    }
}
