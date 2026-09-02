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

        public async Task<List<TradingMarketInfo>> GetAllMarketsAsync(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<TradingMarketInfo>>($"{_controllerPath}/all", ct) ?? new List<TradingMarketInfo>();
        }
        public async Task<TradingHallHeaderData?> GetHeaderDataAsync(int marketId, CancellationToken ct = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<TradingHallHeaderData>($"{_controllerPath}/{marketId}/header", ct);
            }
            catch
            {
                return new TradingHallHeaderData("تالار معاملات", "بورس کالا");
            }
        }

        public async Task<HallStatusData?> GetStatusDataAsync(int marketId, CancellationToken ct = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<HallStatusData>($"{_controllerPath}/{marketId}/status", ct);
            }
            catch
            {
                return null;
            }
        }

        public async Task<DailyHighlightsData?> GetHighlightsDataAsync(int marketId, CancellationToken ct = default)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<DailyHighlightsData>($"{_controllerPath}/{marketId}/highlights", ct);
            }
            catch
            {
                return new DailyHighlightsData();
            }
        }
        
        public async Task<List<OfferListItem>> GetTradedOffersAsync(int marketId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<OfferListItem>>($"{_controllerPath}/{marketId}/offers/traded", ct) ?? new List<OfferListItem>();
        }

        public async Task<List<OfferListItem>> GetUntradedOffersAsync(int marketId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<OfferListItem>>($"{_controllerPath}/{marketId}/offers/untraded", ct) ?? new List<OfferListItem>();
        }

        public async Task<List<OfferListItem>> GetFailedOffersAsync(int marketId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<OfferListItem>>($"{_controllerPath}/{marketId}/offers/failed", ct) ?? new List<OfferListItem>();
        }
    }
}
