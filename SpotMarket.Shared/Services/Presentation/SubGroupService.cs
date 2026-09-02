using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface ISubGroupService
    {
        Task<GroupListData> GetActiveCommoditiesAsync(int subGroupId, CancellationToken ct = default);
        Task<MarketConditionsData> GetCommodityActivitiesAsync(int subGroupId, CancellationToken ct = default);
        Task<UpcomingOffersData> GetOfferHistoryAsync(int subGroupId, CancellationToken ct = default);
        Task<SubGroupHeaderData> GetSubGroupHeaderDataAsync(int subGroupId, CancellationToken ct = default);
        Task<List<HierarchyItem>> GetSubGroupHierarchyAsync(int subGroupId, CancellationToken ct = default);
    }

    public class SubGroupService : ISubGroupService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/SubGroup";

        public SubGroupService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GroupListData> GetActiveCommoditiesAsync(int subGroupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<GroupListData>($"{_controllerPath}/{subGroupId}/commodities", ct) ?? new GroupListData();
        }

        public async Task<MarketConditionsData> GetCommodityActivitiesAsync(int subGroupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<MarketConditionsData>($"{_controllerPath}/{subGroupId}/activities", ct) ?? new MarketConditionsData();
        }
        public async Task<UpcomingOffersData> GetOfferHistoryAsync(int subGroupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<UpcomingOffersData>($"{_controllerPath}/{subGroupId}/offer-history", ct) ?? new UpcomingOffersData();
        }
        public async Task<SubGroupHeaderData> GetSubGroupHeaderDataAsync(int subGroupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<SubGroupHeaderData>($"{_controllerPath}/{subGroupId}/header", ct) ?? new SubGroupHeaderData();
        }
        public async Task<List<HierarchyItem>> GetSubGroupHierarchyAsync(int subGroupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<HierarchyItem>>($"{_controllerPath}/{subGroupId}/hierarchy", ct) ?? new List<HierarchyItem>();
        }

    }

}
