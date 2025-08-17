using SpotMarket.WebAssembly.Models.Presentation;

namespace SpotMarket.WebAssembly.Services.Presentation
{
    // OfferDataModels.cs

    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public interface IOfferDetailsService
    {
        Task<OfferViewModel> GetOfferByIdAsync(int offerId);
    }

    // Service to provide sample data, mimicking a real data service
    public class OfferDetailsService : IOfferDetailsService
    {
        private readonly string _controllerPath = "/api/OfferDetails";
        private readonly HttpClient _httpClient;

        public OfferDetailsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<OfferViewModel> GetOfferByIdAsync(int offerId)
        {
            return await _httpClient.GetFromJsonAsync<OfferViewModel>($"{_controllerPath}/{offerId}") ?? new OfferViewModel();
            //var offers = new List<OfferViewModel>
            //{
            //    new OfferViewModel
            //    {
            //        Id = 1,
            //        CommodityName = "شمش فولادی",
            //        OfferRing = "صنعتی",
            //        RingIconCssClass = "industrial",
            //        ContractType = "نقدی",
            //        Supplier = "فولاد مبارکه اصفهان",
            //        Manufacturer = "فولاد مبارکه اصفهان",
            //        Broker = "کارگزاری مفید",
            //        OfferDate = "۱۴۰۴/۰۶/۲۵",
            //        DeliveryDate = "۱۴۰۴/۰۷/۱۵",
            //        InitialPrice = 245_000_000,
            //        OfferVolume = 2_200,
            //        MeasurementUnit = "تن",
            //        CurrencyUnit = "ریال",
            //        MinOrderVolume = 22,
            //        MaxOrderVolume = 110,
            //        LotCoefficient = 22,
            //        LotSize = 1,
            //        PrepaymentPercent = 10,
            //        TickSize = 100_000,
            //        Description = "شمش فولادی (بیلت) 150x150 میلیمتر از نوع 5SP مطابق با استاندارد GOST 380. محل تحویل، انبار کارخانه می‌باشد. تسویه به صورت نقدی انجام خواهد شد."
            //    },
            //    new OfferViewModel
            //    {
            //        Id = 2,
            //        CommodityName = "پلی پروپیلن نساجی",
            //        OfferRing = "پتروشیمی",
            //        RingIconCssClass = "petro",
            //        ContractType = "سلف",
            //        Supplier = "پتروشیمی مارون",
            //        Manufacturer = "پتروشیمی مارون",
            //        Broker = "کارگزاری آگاه",
            //        OfferDate = "۱۴۰۴/۰۶/۲۵",
            //        DeliveryDate = "۱۴۰۴/۰۹/۲۰",
            //        InitialPrice = 480_000_000,
            //        OfferVolume = 506,
            //        MeasurementUnit = "تن",
            //        CurrencyUnit = "ریال",
            //        MinOrderVolume = 22,
            //        MaxOrderVolume = 44,
            //        LotCoefficient = 22,
            //        LotSize = 1,
            //        PrepaymentPercent = 100,
            //        TickSize = 500_000,
            //        Description = "پلی پروپیلن گرید Z30S. تحویل درب انبار پتروشیمی در ماهشهر. هزینه‌های جانبی طبق اطلاعیه محاسبه می‌گردد."
            //    },
            //    new OfferViewModel
            //    {
            //        Id = 3,
            //        CommodityName = "سیمان تیپ ۲",
            //        OfferRing = "صنعتی",
            //        RingIconCssClass = "cement",
            //        ContractType = "نقدی",
            //        Supplier = "سیمان تهران",
            //        Manufacturer = "سیمان تهران",
            //        Broker = "کارگزاری بانک سامان",
            //        OfferDate = "۱۴۰۴/۰۶/۲۶",
            //        DeliveryDate = "۱۴۰۴/۰۷/۰۵",
            //        InitialPrice = 12_500_000,
            //        OfferVolume = 10_000,
            //        MeasurementUnit = "تن",
            //        CurrencyUnit = "ریال",
            //        MinOrderVolume = 25,
            //        MaxOrderVolume = 250,
            //        LotCoefficient = 25,
            //        LotSize = 1,
            //        PrepaymentPercent = 10,
            //        TickSize = 50_000,
            //        Description = "سیمان پرتلند تیپ 2 فله‌ای. تحویل از درب کارخانه واقع در استان تهران. خریداران موظف به ارائه مدارک حمل معتبر می‌باشند."
            //    }
            //};

            //return Task.FromResult(offers);
        }
    }
}
