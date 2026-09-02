using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface IMainGroupService
    {
        Task<GroupListData> GetActiveGroupsAsync(int mainGroupId, CancellationToken ct = default);
        Task<MarketConditionsData> GetGroupActivitiesAsync(int mainGroupId, CancellationToken ct = default);
        Task<UpcomingOffersData> GetUpcomingOffersAsync(int mainGroupId, CancellationToken ct = default);
        Task<MarketStatsData> GetMarketShareAsync(int mainGroupId, CancellationToken ct = default);
        Task<MarketStatsData> GetTradeShareAsync(int mainGroupId, CancellationToken ct = default);
    }

    public class MainGroupService : IMainGroupService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/MainGroup";

        public MainGroupService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GroupListData> GetActiveGroupsAsync(int mainGroupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<GroupListData>($"{_controllerPath}/{mainGroupId}/groups", ct) ?? new GroupListData();
        }

        public async Task<MarketConditionsData> GetGroupActivitiesAsync(int mainGroupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<MarketConditionsData>($"{_controllerPath}/{mainGroupId}/activities", ct) ?? new MarketConditionsData();
        }
        public async Task<UpcomingOffersData> GetUpcomingOffersAsync(int mainGroupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<UpcomingOffersData>($"{_controllerPath}/{mainGroupId}/upcoming-offers", ct) ?? new UpcomingOffersData();
        }
        public async Task<MarketStatsData> GetMarketShareAsync(int mainGroupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<MarketStatsData>($"{_controllerPath}/{mainGroupId}/market-share", ct) ?? new MarketStatsData();
        }
        public async Task<MarketStatsData> GetTradeShareAsync(int mainGroupId, CancellationToken ct = default) 
        {
            return await _httpClient.GetFromJsonAsync<MarketStatsData>($"{_controllerPath}/{mainGroupId}/trade-share", ct) ?? new MarketStatsData();
        }

    }

}
