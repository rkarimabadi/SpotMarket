using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;

namespace SpotMarket.Shared.Services.Presentation
{
    public class CementService : ICementService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/Broker";

        public CementService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CementGroupsData> GetCementGroupsDataAsync()
        {
            await Task.Delay(500); // شبیه‌سازی تأخیر شبکه

            return new CementGroupsData
            {
                ActiveGroups = new List<CementGroupStatusItem>
                {
                    new() { Name = "سیمان پرتلند تیپ ۲", Subtitle = "سیمان تهران، سیمان آبیک", UrlName = "/cement/type-2", Status = GroupActivityStatus.HasOfferToday, OfferCount = 8, DemandStatus = DemandStatus.High },
                    new() { Name = "سیمان پرتلند تیپ ۱", Subtitle = "سیمان سپاهان، سیمان ساوه", UrlName = "/cement/type-1", Status = GroupActivityStatus.HasUpcomingOffer, OfferCount = 3, DemandStatus = DemandStatus.Medium },
                    new() { Name = "سیمان سفید پرتلند", Subtitle = "سیمان سفید شرق", UrlName = "/cement/white", Status = GroupActivityStatus.HasUpcomingOffer, OfferCount = 1, DemandStatus = DemandStatus.Low }
                },
                InactiveGroups = new List<CementGroupStatusItem>
                {
                    new() { Name = "سیمان پوزولانی", UrlName = "/cement/pozzolana", Status = GroupActivityStatus.Inactive, OfferCount = 0 },
                    new() { Name = "سیمان سرباره‌ای", UrlName = "/cement/slag", Status = GroupActivityStatus.Inactive, OfferCount = 0 },
                    new() { Name = "سیمان مرکب", UrlName = "/cement/composite", Status = GroupActivityStatus.Inactive, OfferCount = 0 }
                }
            };
        }
        public async Task<CementQuickPathData> GetCementQuickPathDataAsync()
        {
            await Task.Delay(500); // شبیه‌سازی تأخیر شبکه

            return new CementQuickPathData
            {
                Items = new List<QuickPathItem>
                {
                    new() { Title = "تیپ ۲ پاکتی", UrlName = "/cement/type-2/bagged", IconCssClass = "bi bi-bag-fill", ThemeCssClass = "theme-blue" },
                    new() { Title = "تیپ ۱ فله", UrlName = "/cement/type-1/bulk", IconCssClass = "bi bi-truck", ThemeCssClass = "theme-green" },
                    new() { Title = "سیمان سفید", UrlName = "/cement/white", IconCssClass = "bi bi-palette-fill", ThemeCssClass = "theme-purple" },
                    new() { Title = "جامبوبگ", UrlName = "/cement/jumbobag", IconCssClass = "bi bi-box-fill", ThemeCssClass = "theme-orange" }
                }
            };
        }
        public async Task<BasicCementMarketSummary> GetBasicCementMarketSummaryDataAsync()
        {
            await Task.Delay(500); // شبیه‌سازی تأخیر شبکه

            return new BasicCementMarketSummary
            {
                Value = "۸۵.۲ همت",
                Label = "ارزش کل معاملات امروز",
                Subtitle = "با میانگین رقابت +۲.۱٪",
            };
        }
        public async Task<CementMarketSummary> GetCementMarketSummaryDataAsync()
        {
            await Task.Delay(500); // شبیه‌سازی تأخیر شبکه

            return new CementMarketSummary
            {
                TotalValue = "۱۲۵.۳ همت",
                TotalVolume = "۱۵۰ هزار تن",
                TodayOffersCount = 42,
                CompetitionValue = "+۱۰.۵٪",
                CompetitionPercentage = 0.75, // 75%
                DemandValue = "۲.۴x",
                DemandPercentage = 0.8, // 80%
                IsPositive = true
            };
        }
    }
}
