using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;
namespace SpotMarket.Shared.Services.Presentation
{
    public interface ISearchService
    {
        Task<SearchResultsData> GlobalSearchAsync(string term);
    }

    public class SearchService : ISearchService
    {
        private readonly string _controllerPath = "/api/Search";
        private readonly HttpClient _httpClient;

        public SearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<SearchResultsData> GlobalSearchAsync(string term)
        {
            return await _httpClient.GetFromJsonAsync<SearchResultsData>($"{_controllerPath}/{term}") ?? new SearchResultsData();
        }
        
    }
}
