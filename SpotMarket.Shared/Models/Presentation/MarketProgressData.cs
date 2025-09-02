namespace SpotMarket.Shared.Models.Presentation
{
    /// <summary>
    /// مدل اصلی برای نگهداری داده‌های ویجت پیشرفت بازار.
    /// </summary>
    public class MarketProgressData
    {
        public List<MarketProgressDetail> Items { get; set; } = new();

        public int TotalOffers => Items.Sum(m => m.TotalOffers);
        public int TotalTradedOffers => Items.Sum(m => m.TradedOffers);
        public double TotalProgressPercentage => TotalOffers > 0 ? (double)TotalTradedOffers / TotalOffers * 100 : 0;
    }

    /// <summary>
    /// مدل برای نگهداری جزئیات پیشرفت هر بازار مجزا.
    /// </summary>
    public class MarketProgressDetail
    {
        public string Name { get; set; } = "";
        public int TotalOffers { get; set; }
        public int TradedOffers { get; set; }
        public string CssClass { get; set; } = "";
        public double ProgressPercentage => TotalOffers > 0 ? (double)TradedOffers / TotalOffers * 100 : 0;
    }
}
