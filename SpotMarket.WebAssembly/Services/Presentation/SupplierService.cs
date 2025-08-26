using SpotMarket.WebAssembly.Models.Presentation;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SpotMarket.WebAssembly.Services.Presentation
{
    public class SupplierService : ISupplierService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/Supplier";

        public SupplierService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Fetches the header data for a specific supplier.
        /// </summary>
        public async Task<SupplierHeaderData?> GetSupplierHeaderAsync(int supplierId)
        {
            // This makes a call to an API endpoint like: GET /api/Supplier/{supplierId}/header
            return await _httpClient.GetFromJsonAsync<SupplierHeaderData>($"{_controllerPath}/{supplierId}/header");
        }

        /// <summary>
        /// Fetches the breadcrumb hierarchy data for a specific supplier.
        /// </summary>
        public async Task<List<HierarchyItem>?> GetSupplierHierarchyAsync(int supplierId)
        {
            // This makes a call to an API endpoint like: GET /api/Supplier/{supplierId}/hierarchy
            return await _httpClient.GetFromJsonAsync<List<HierarchyItem>>($"{_controllerPath}/{supplierId}/hierarchy");
        }
        /// <summary>
        /// Fetches the ranking data for a specific supplier.
        /// </summary>
        public async Task<List<RankingItem>?> GetSupplierRankingAsync(int supplierId)
        {
            // This makes a call to an API endpoint like: GET /api/Supplier/{supplierId}/ranking
            return await _httpClient.GetFromJsonAsync<List<RankingItem>>($"{_controllerPath}/{supplierId}/ranking");
        }
        public async Task<IEnumerable<MainPlayer>?> GetMainPlayersAsync(int supplierId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MainPlayer>>($"{_controllerPath}/{supplierId}/main-players");
        }
        public async Task<List<CommodityGroupShareItem>?> GetMarketShareAsync(int supplierId)
        {
            return await _httpClient.GetFromJsonAsync<List<CommodityGroupShareItem>>($"{_controllerPath}/{supplierId}/market-share");
        }
        public async Task<CompetitionData?> GetCompetitionRatioAsync(int supplierId)
        {
            return await _httpClient.GetFromJsonAsync<CompetitionData>($"{_controllerPath}/{supplierId}/competition-ratio");
        }
        public async Task<MarketMetricData?> GetMarketMetricAsync(int supplierId)
        {
            return await _httpClient.GetFromJsonAsync<MarketMetricData>($"{_controllerPath}/{supplierId}/market-metric");
        }
        public async Task<SupplierCommodityAnalysisData?> GetSupplierCommodityAnalysisAsync(int supplierId)
        {
            return await _httpClient.GetFromJsonAsync<SupplierCommodityAnalysisData>($"{_controllerPath}/{supplierId}/commodity-analysis");
        }

        /// <summary>
        /// Fetches the seasonal activity data for a specific supplier.
        /// </summary>
        public async Task<SeasonalActivityData?> GetSeasonalActivityAsync(int supplierId)
        {
            return await _httpClient.GetFromJsonAsync<SeasonalActivityData?>($"{_controllerPath}/{supplierId}/seasonal-activity") ?? new SeasonalActivityData();

            // --- Sample Data Generation ---
            //var sampleData = new SeasonalActivityData
            //{
            //    SeasonActivities = new List<SeasonActivityItem>
            //    {
            //        new() { SeasonName = "بهار", OfferCount = 85 },
            //        new() { SeasonName = "تابستان", OfferCount = 150 },
            //        new() { SeasonName = "پاییز", OfferCount = 120 },
            //        new() { SeasonName = "زمستان", OfferCount = 40 }
            //    }
            //};

            //var maxOffers = sampleData.SeasonActivities.Max(s => s.OfferCount);
            //if (maxOffers > 0)
            //{
            //    foreach (var season in sampleData.SeasonActivities)
            //    {
            //        // Normalize the activity level from 0.2 (min visibility) to 1.0 (max)
            //        season.ActivityLevel = 0.2 + (0.8 * season.OfferCount / maxOffers);
            //    }
            //}
            //sampleData.PeakSeasonName = sampleData.SeasonActivities.OrderByDescending(s => s.OfferCount).First().SeasonName;

            //return await Task.FromResult(sampleData);
        }
    }
}
