using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface IMainGroupService
    {
        Task<GroupListData> GetActiveGroupsAsync(int mainGroupId);
        Task<MarketConditionsData> GetGroupActivitiesAsync(int mainGroupId);
        Task<UpcomingOffersData> GetUpcomingOffersAsync(int mainGroupId);
        Task<MarketStatsData> GetMarketShareAsync(int mainGroupId);
        Task<MarketStatsData> GetTradeShareAsync(int mainGroupId);
    }

    public class MainGroupService : IMainGroupService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/MainGroup";

        public MainGroupService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GroupListData> GetActiveGroupsAsync(int mainGroupId)
        {
            return await _httpClient.GetFromJsonAsync<GroupListData>($"{_controllerPath}/{mainGroupId}/groups") ?? new GroupListData();
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

        public async Task<MarketConditionsData> GetGroupActivitiesAsync(int mainGroupId)
        {
            return await _httpClient.GetFromJsonAsync<MarketConditionsData>($"{_controllerPath}/{mainGroupId}/activities") ?? new MarketConditionsData();
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
        public async Task<UpcomingOffersData> GetUpcomingOffersAsync(int mainGroupId)
        {
            return await _httpClient.GetFromJsonAsync<UpcomingOffersData>($"{_controllerPath}/{mainGroupId}/upcoming-offers") ?? new UpcomingOffersData();
            //var data = new UpcomingOffersData
            //{
            //    Items = new List<UpcomingOfferItem>
            //    {
            //        new() { DayOfWeek = "شنبه", DayOfMonth = "۲۰", Title = "عرضه شمش فولادی", Subtitle = "توسط فولاد خوزستان" },
            //        new() { DayOfWeek = "دوشنبه", DayOfMonth = "۲۲", Title = "عرضه ورق گرم", Subtitle = "توسط فولاد مبارکه" }
            //    }
            //};
            //return await Task.FromResult(data);
        }
        public async Task<MarketStatsData> GetMarketShareAsync(int mainGroupId)
        {
            return await _httpClient.GetFromJsonAsync<MarketStatsData>($"{_controllerPath}/{mainGroupId}/market-share") ?? new MarketStatsData();
            //var data = new UpcomingOffersData
            //{
            //    Items = new List<UpcomingOfferItem>
            //    {
            //        new() { DayOfWeek = "شنبه", DayOfMonth = "۲۰", Title = "عرضه شمش فولادی", Subtitle = "توسط فولاد خوزستان" },
            //        new() { DayOfWeek = "دوشنبه", DayOfMonth = "۲۲", Title = "عرضه ورق گرم", Subtitle = "توسط فولاد مبارکه" }
            //    }
            //};
            //return await Task.FromResult(data);
        }
        public async Task<MarketStatsData> GetTradeShareAsync(int mainGroupId) 
        {
            return await _httpClient.GetFromJsonAsync<MarketStatsData>($"{_controllerPath}/{mainGroupId}/trade-share") ?? new MarketStatsData();
        }

    }

}

