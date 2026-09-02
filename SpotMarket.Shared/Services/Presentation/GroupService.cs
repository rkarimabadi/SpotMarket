using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;
namespace SpotMarket.Shared.Services.Presentation
{
    public interface IGroupService
    {
        Task<GroupListData> GetActiveSubGroupsAsync(int groupId, CancellationToken ct = default);
        Task<MarketConditionsData> GetSubGroupActivitiesAsync(int groupId, CancellationToken ct = default);
        Task<UpcomingOffersData> GetUpcomingOffersAsync(int groupId, CancellationToken ct = default);
        Task<UpcomingOffersData> GetTodayOffersAsync(int groupId, CancellationToken ct = default);
        Task<GroupHeaderData> GetGroupHeaderDataAsync(int groupId, CancellationToken ct = default);
        Task<List<HierarchyItem>> GetGroupHierarchyAsync(int groupId, CancellationToken ct = default);
    }

    public class GroupService : IGroupService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/Group";

        public GroupService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GroupListData> GetActiveSubGroupsAsync(int groupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<GroupListData>($"{_controllerPath}/{groupId}/sub-groups", ct) ?? new GroupListData();
        }

        public async Task<MarketConditionsData> GetSubGroupActivitiesAsync(int groupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<MarketConditionsData>($"{_controllerPath}/{groupId}/activities", ct) ?? new MarketConditionsData();
        }
        public async Task<UpcomingOffersData> GetUpcomingOffersAsync(int groupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<UpcomingOffersData>($"{_controllerPath}/{groupId}/upcoming-offers", ct) ?? new UpcomingOffersData();
        }
        public async Task<UpcomingOffersData> GetTodayOffersAsync(int groupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<UpcomingOffersData>($"{_controllerPath}/{groupId}/today-offers", ct) ?? new UpcomingOffersData();
        }
        public async Task<GroupHeaderData> GetGroupHeaderDataAsync(int groupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<GroupHeaderData>($"{_controllerPath}/{groupId}/header", ct) ?? new GroupHeaderData();
        }
        public async Task<List<HierarchyItem>> GetGroupHierarchyAsync(int groupId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<List<HierarchyItem>>($"{_controllerPath}/{groupId}/hierarchy", ct) ?? new List<HierarchyItem>();
        }

    }

}
