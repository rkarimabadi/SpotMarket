using SpotMarket.Shared.Models.Presentation;

namespace SpotMarket.Shared.Services.Presentation
{
    public class MockTradingHallService : ITradingHallService
    {
        public Task<TradingHallHeaderData?> GetHeaderDataAsync()
        {
            var data = new TradingHallHeaderData("تالار معاملات فیزیکی", "بورس کالای ایران");
            return Task.FromResult<TradingHallHeaderData?>(data);
        }

        public Task<HallStatusData?> GetStatusDataAsync()
        {
            var data = new HallStatusData
            {
                TotalOffers = 128,
                TradedOffers = 75,
                InTradingOffers = 12,
                Status = HallStatus.Open,
                StartTime = new TimeSpan(10, 30, 0),
                EndTime = new TimeSpan(17, 0, 0)
            };
            return Task.FromResult<HallStatusData?>(data);
        }

        public Task<DailyHighlightsData?> GetHighlightsDataAsync()
        {
            var data = new DailyHighlightsData
            {
                TopValueTrades = new List<HighlightItem>
                {
                    new("شمش فولاد خوزستان", "۲/۰۳ همت", "ارزش کل معاملات"),
                    new("مس کاتد", "۱/۸۷ همت", "ارزش کل معاملات"),
                },
                HottestCompetitions = new List<HighlightItem>
                {
                    new("میلگرد آجدار A3", "+۴۵.۲٪", "رقابت از قیمت پایه"),
                    new("زعفران نگین", "+۳۱.۰٪", "رقابت از قیمت پایه")
                },
                HeaviestCompetitions = new List<HighlightItem>
                {
                    new("قیر پالایش نفت جی", "۳۲۰٪", "نسبت تقاضا به عرضه"),
                    new("وکیوم باتوم", "۲۸۰٪", "نسبت تقاضا به عرضه"),
                }
            };
            return Task.FromResult<DailyHighlightsData?>(data);
        }
    }
}
