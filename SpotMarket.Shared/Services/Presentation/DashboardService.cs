using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;


namespace SpotMarket.Shared.Services.Presentation
{
    public interface IDashboardService
    {
        Task<MarketProgressData> GetMarketProgressData(CancellationToken ct = default);
        Task<MarketPulseData> GetMarketPulse(CancellationToken ct = default);
        Task<MarketSentimentData> GetMarketSentiment(CancellationToken ct = default);
        Task<MarketExcitementData> GetMarketExcitement(CancellationToken ct = default);
        Task<SupplyRiskData> GetSupplyRisk(CancellationToken ct = default);
        Task<MarketMoversData> GetMarketMovers(CancellationToken ct = default);
        Task<IEnumerable<MainPlayer>> GetMainPlayers(CancellationToken ct = default);
        Task<TradingHallsData> GetTradingHalls(CancellationToken ct = default);
        Task<NewsData> GetNews(CancellationToken ct = default);
        Task<SpotNotificationData> GetspotNotifications(CancellationToken ct = default);
    }

    public class DashboardService : IDashboardService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/dashboard";

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MarketPulseData> GetMarketPulse(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<MarketPulseData>($"{_controllerPath}/market-pulse", ct);
        }

        public async Task<MarketSentimentData> GetMarketSentiment(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<MarketSentimentData>($"{_controllerPath}/market-sentiment", ct);
        }

        public async Task<MarketExcitementData> GetMarketExcitement(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<MarketExcitementData>($"{_controllerPath}/market-excitement", ct);
        }

        public async Task<SupplyRiskData> GetSupplyRisk(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<SupplyRiskData>($"{_controllerPath}/supply-risk", ct);
        }

        public async Task<MarketMoversData> GetMarketMovers(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<MarketMoversData>($"{_controllerPath}/market-movers", ct);
        }

        public async Task<IEnumerable<MainPlayer>> GetMainPlayers(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MainPlayer>>($"{_controllerPath}/main-players", ct);
        }

        public async Task<TradingHallsData> GetTradingHalls(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<TradingHallsData>($"{_controllerPath}/trading-halls", ct);
        }
        
        public async Task<NewsData> GetNews(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<NewsData>($"{_controllerPath}/news", ct);
        }
        public async Task<SpotNotificationData> GetspotNotifications(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<SpotNotificationData>($"{_controllerPath}/Spot-notifications", ct);
        }

        public async Task<MarketProgressData> GetMarketProgressData(CancellationToken ct = default)
        {
             return await _httpClient.GetFromJsonAsync<MarketProgressData>($"{_controllerPath}/market-progress", ct);
        }
    }

}
