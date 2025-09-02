namespace SpotMarket.Shared.Models.Presentation
{
    /// <summary>
    /// مدل داده برای ویجت "برنامه عرضه‌های آینده"
    /// </summary>
    public class UpcomingOffersData
    {
        public List<UpcomingOfferItem> Items { get; set; } = new();
    }
}
