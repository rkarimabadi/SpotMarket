using System.Net.Http.Json;
using SpotMarket.WebAssembly.Models.Presentation;

namespace SpotMarket.WebAssembly.Services.Presentation
{
    public interface IDashboardService
    {
        Task<MarketProgressData> GetMarketProgressData();
        Task<MarketPulseData> GetMarketPulse();
        Task<MarketSentimentData> GetMarketSentiment();
        Task<MarketExcitementData> GetMarketExcitement();
        Task<SupplyRiskData> GetSupplyRisk();
        Task<MarketMoversData> GetMarketMovers();
        Task<IEnumerable<MainPlayer>> GetMainPlayers();
        Task<TradingHallsData> GetTradingHalls();
        Task<NewsData> GetNews();
    }

    public class DashboardService : IDashboardService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/dashboard";

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MarketPulseData> GetMarketPulse()
        {
            return await _httpClient.GetFromJsonAsync<MarketPulseData>($"{_controllerPath}/market-pulse");
        }

        public async Task<MarketSentimentData> GetMarketSentiment()
        {
            return await _httpClient.GetFromJsonAsync<MarketSentimentData>($"{_controllerPath}/market-sentiment");
        }

        public async Task<MarketExcitementData> GetMarketExcitement()
        {
            return await _httpClient.GetFromJsonAsync<MarketExcitementData>($"{_controllerPath}/market-excitement");
        }

        public async Task<SupplyRiskData> GetSupplyRisk()
        {
            return await _httpClient.GetFromJsonAsync<SupplyRiskData>($"{_controllerPath}/supply-risk");
        }

        public async Task<MarketMoversData> GetMarketMovers()
        {
            return await _httpClient.GetFromJsonAsync<MarketMoversData>($"{_controllerPath}/market-movers");
        }

        public async Task<IEnumerable<MainPlayer>> GetMainPlayers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MainPlayer>>($"{_controllerPath}/main-players");
        }

        public async Task<TradingHallsData> GetTradingHalls()
        {
            return await _httpClient.GetFromJsonAsync<TradingHallsData>($"{_controllerPath}/trading-halls");
        }
        
        public async Task<NewsData> GetNews()
        {
            return await _httpClient.GetFromJsonAsync<NewsData>($"{_controllerPath}/news");
        }

        public async Task<MarketProgressData> GetMarketProgressData()
        {
             return await _httpClient.GetFromJsonAsync<MarketProgressData>($"{_controllerPath}/market-progress");
        }
    }

}

