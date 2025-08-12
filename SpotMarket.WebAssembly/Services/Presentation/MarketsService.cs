using System.Net.Http.Json;
using SpotMarket.WebAssembly.Models.Presentation;

namespace SpotMarket.WebAssembly.Services.Presentation
{
    public interface IMarketsService
    {
        Task<List<MarketInfo>> GetMainGroupsData();
        Task<CommodityStatusData> GetIndexGroups();
        Task<List<MarketActivity>> GetMarketActivities();
        Task<MarketContactsData> GetMarketContacts();
    }

    public class MarketsService : IMarketsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/Markets";

        public MarketsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MarketInfo>> GetMainGroupsData()
        {
            return await _httpClient.GetFromJsonAsync<List<MarketInfo>>($"{_controllerPath}/main-groups") ?? new List<MarketInfo>();
            //return new List<MarketInfo>
            //{
            //    new MarketInfo("صنعتی", "فولاد، مس، آلومینیوم", "Industrial", "bi-building", "industrial", "high", "داغ"),
            //    new MarketInfo("کشاورزی", "زعفران، پسته، جو", "Agriculture", "bi-tree-fill", "agri", "low", "آرام"),
            //    new MarketInfo("پتروشیمی و فرآورده های نفتی", "پلیمرها، مواد شیمیایی، نفت", "Petrochemical-and-Oil-Products", "bi-droplet-fill", "petro", "medium", "متوسط"),
            //    new MarketInfo("معدنی", "سنگ آهن، زغال سنگ", "Mineral", "bi-gem", "mineral", "medium", "متوسط"),
            //    new MarketInfo("فرآورده های نفتی", "قیر، روغن، گاز", "Oil-Products", "bi-fuel-pump-fill", "oil-products", "high", "داغ"),
            //    new MarketInfo("اموال غیر منقول", "ساختمان، زمین، مستغلات", "Real-Estate", "bi-house-door-fill", "real-estate", "low", "آرام"),
            //    new MarketInfo("بازار فرعی", "کالاهای متنوع", "Secondary-Market", "bi-shop", "secondary", "neutral", "خنثی")
            //};
        }

        public async Task<CommodityStatusData> GetIndexGroups()
        {
            return await _httpClient.GetFromJsonAsync<CommodityStatusData>($"{_controllerPath}/index-groups") ?? new CommodityStatusData();

            //return new CommodityStatusData
            //{
            //    Items = new List<CommodityStatusItem>
            //    {
            //        new() { Name = "ضایعات فولاد", MainGroupName = "صنعتی", OfferCount = 5, DemandStatus = DemandStatus.High },
            //        new() { Name = "زعفران", MainGroupName = "کشاورزی", OfferCount = 12, DemandStatus = DemandStatus.Low },
            //        new() { Name = "سنگ آهن", MainGroupName = "معدنی", OfferCount = 8, DemandStatus = DemandStatus.High },
            //        new() { Name = "پلیمر", MainGroupName = "پتروشیمی", OfferCount = 31, DemandStatus = DemandStatus.High },
            //        new() { Name = "قیر خالص", MainGroupName = "فرآورده های نفتی", OfferCount = 7, DemandStatus = DemandStatus.Medium },
            //    }
            //};
        }

        public async Task<List<MarketActivity>> GetMarketActivities()
        {
            return await _httpClient.GetFromJsonAsync<List<MarketActivity>>($"{_controllerPath}/market-activities") ?? new List<MarketActivity>();
            //var data = new List<MarketActivity>
            //{
            //    new MarketActivity("صنعتی", "industrial", 0.92, "۹۲٪ انجام شده", "۵.۸ همت"),
            //    new MarketActivity("پتروشیمی", "petro", 0.78, "۷۸٪ انجام شده", "۴.۲ همت"),
            //    new MarketActivity("کشاورزی", "agri", 0.65, "۶۵٪ انجام شده", "۱.۱ همت")
            //};
            //return await Task.FromResult(data);
        }
        public async Task<MarketContactsData> GetMarketContacts()
        {
            var data = new MarketContactsData
                {
                    Items = new List<MarketContactItem>
                    {
                        new() { Title = "شمش‌بلوم", Subtitle = "غول حجم", IconCssClass = "bi bi-building", AvatarCssClass = "steel" },
                        new() { Title = "مس", Subtitle = "قهرمان ارزش", IconCssClass = "bi bi-gem", AvatarCssClass = "agri" },
                        new() { Title = "پلی‌اتیلن", Subtitle = "ستون‌فقرات", IconCssClass = "bi bi-droplet-fill", AvatarCssClass = "petro" },
                        new() { Title = "سیمان", Subtitle = "شالوده توسعه", IconCssClass = "bi bi-cone-striped", AvatarCssClass = "cement" }
                    }
                };
            return await Task.FromResult(data);
        }
    }

}

