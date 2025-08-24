using System.Net.Http.Json;
using SpotMarket.WebAssembly.Models.Presentation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpotMarket.WebAssembly.Services.Presentation
{
    public interface ISubGroupService
    {
        Task<GroupListData> GetActiveCommoditiesAsync(int subGroupId);
        Task<MarketConditionsData> GetCommodityActivitiesAsync(int subGroupId);
        Task<UpcomingOffersData> GetOfferHistoryAsync(int subGroupId);
        Task<SubGroupHeaderData> GetSubGroupHeaderDataAsync(int subGroupId);
        Task<List<HierarchyItem>> GetSubGroupHierarchyAsync(int subGroupId);
    }

    public class SubGroupService : ISubGroupService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/SubGroup";

        public SubGroupService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GroupListData> GetActiveCommoditiesAsync(int subGroupId)
        {
            return await _httpClient.GetFromJsonAsync<GroupListData>($"{_controllerPath}/{subGroupId}/commodities") ?? new GroupListData();
            //return new GroupListData
            //{ 
            //    Items = new List<GroupListItem>
            //     {
            //        // --- گروه‌های فعال ---
            //        new() {
            //            Title = "ورق گرم",
            //            UrlName = "hot-rolled-sheet",
            //            Status = GroupActivityStatus.HasOfferToday,
            //            OfferCount = 3,
            //            Subtitle = "شامل ورق گرم، سرد و گالوانیزه"
            //        },
            //        new() {
            //            Title = "میلگرد",
            //            UrlName = "rebar",
            //            Status = GroupActivityStatus.HasOfferToday,
            //            OfferCount = 8,
            //            Subtitle = "شامل ورق گرم، سرد و گالوانیزه"
            //        },
            //        new() {
            //            Title = "شمش فولادی",
            //            UrlName = "steel-billet",
            //            Status = GroupActivityStatus.HasUpcomingOffer,
            //            OfferCount = 5,
            //            Subtitle = "شامل ورق گرم، سرد و گالوانیزه" 
            //        },
            //        // --- گروه‌های غیرفعال ---
            //        new() {
            //            Title = "تیرآهن",
            //            UrlName = "beam",
            //            Subtitle = "شامل ورق گرم، سرد و گالوانیزه",
            //            Status = GroupActivityStatus.Inactive
            //        },
            //        new() {
            //            Title = "ورق سرد",
            //            UrlName = "cold-rolled-sheet",
            //            Subtitle = "شامل ورق گرم، سرد و گالوانیزه",
            //            Status = GroupActivityStatus.Inactive
            //        },
            //        new() {
            //            Title = "سیمان",
            //            UrlName = "cement",
            //            Subtitle = "شامل ورق گرم، سرد و گالوانیزه",
            //            Status = GroupActivityStatus.Inactive
            //        },
            //         new() {
            //            Title = "مس کاتد",
            //            UrlName = "copper-cathode",
            //            Subtitle = "شامل ورق گرم، سرد و گالوانیزه",
            //            Status = GroupActivityStatus.Inactive
            //        }
            //    }
            //};
        }

        public async Task<MarketConditionsData> GetCommodityActivitiesAsync(int subGroupId)
        {
            return await _httpClient.GetFromJsonAsync<MarketConditionsData>($"{_controllerPath}/{subGroupId}/activities") ?? new MarketConditionsData();
            //var data = new MarketConditionsData
            //    {
            //        Items = new List<MarketConditionItem>
            //        {
            //            new() { Title = "ارزش معاملات", Value = "۵.۸", Unit = "همت", IconCssClass = "bi bi-cash-stack", IconBgCssClass = "value" },
            //            new() { Title = "حجم معاملات", Value = "۸۴.۵", Unit = "هزار تن", IconCssClass = "bi bi-truck", IconBgCssClass = "volume" },
            //            new() { Title = "شاخص رقابت", Value = "+۱۲.۵٪", IconCssClass = "bi bi-fire", IconBgCssClass = "competition", ValueState = ValueState.Positive },
            //            new() { Title = "قدرت تقاضا", Value = "۱.۸x", IconCssClass = "bi bi-people", IconBgCssClass = "demand" }
            //        }
            //    };
            //return await Task.FromResult(data);
        }
        public async Task<UpcomingOffersData> GetOfferHistoryAsync(int subGroupId)
        {
            return await _httpClient.GetFromJsonAsync<UpcomingOffersData>($"{_controllerPath}/{subGroupId}/offer-history") ?? new UpcomingOffersData();
        }
        public async Task<SubGroupHeaderData> GetSubGroupHeaderDataAsync(int subGroupId)
        {
            return await _httpClient.GetFromJsonAsync<SubGroupHeaderData>($"{_controllerPath}/{subGroupId}/header") ?? new SubGroupHeaderData();
        }
        public async Task<List<HierarchyItem>> GetSubGroupHierarchyAsync(int subGroupId)
        {
            return await _httpClient.GetFromJsonAsync<List<HierarchyItem>>($"{_controllerPath}/{subGroupId}/hierarchy") ?? new List<HierarchyItem>();
        }

    }

}

