using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;
namespace SpotMarket.Shared.Services.Presentation
{
    public interface IMarketsService
    {
        Task<List<MarketInfo>> GetMainGroupsData(CancellationToken ct = default);
        Task<CommodityStatusData> GetIndexGroups(CancellationToken ct = default);
        Task<List<MarketActivity>> GetMarketActivities(CancellationToken ct = default);
        Task<MarketContactsData> GetMarketContacts(CancellationToken ct = default);
        Task<MarketHeatmapData> GetMarketHeatmapData(CancellationToken ct = default);
        Task<MarketShortcutsData> GetMarketShortcutsData(CancellationToken ct = default);
        Task<List<ItemInfo>> GetMarketListAsync(CancellationToken ct = default);
    }

    public class MarketsService : IMarketsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/Markets";

        public MarketsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MarketInfo>> GetMainGroupsData(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<MarketInfo>>($"{_controllerPath}/main-groups", ct) ?? new List<MarketInfo>();
        }

        public async Task<CommodityStatusData> GetIndexGroups(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<CommodityStatusData>($"{_controllerPath}/index-groups", ct) ?? new CommodityStatusData();
        }

        public async Task<List<MarketActivity>> GetMarketActivities(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<MarketActivity>>($"{_controllerPath}/market-activities", ct) ?? new List<MarketActivity>();
        }
        public async Task<MarketContactsData> GetMarketContacts(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<MarketContactsData>($"{_controllerPath}/top-subgroups", ct) ?? new MarketContactsData();
        }
        public async Task<MarketHeatmapData> GetMarketHeatmapData(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<MarketHeatmapData>($"{_controllerPath}/market-heatmap", ct) ?? new MarketHeatmapData();
        }
        public async Task<MarketShortcutsData> GetMarketShortcutsData(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<MarketShortcutsData>($"{_controllerPath}/market-shortcuts", ct) ?? new MarketShortcutsData();
        }
        public async Task<List<ItemInfo>> GetMarketListAsync(CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<ItemInfo>>($"{_controllerPath}/market-list", ct) ?? new List<ItemInfo>();
        }
    }

}
