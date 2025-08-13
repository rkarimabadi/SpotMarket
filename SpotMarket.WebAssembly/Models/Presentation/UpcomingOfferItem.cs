namespace SpotMarket.WebAssembly.Models.Presentation
{
    /// <summary>
    /// نمایانگر یک آیتم در لیست عرضه‌های آینده است
    /// </summary>
    public class UpcomingOfferItem
    {
        public string DayOfWeek { get; set; } = string.Empty;
        public string DayOfMonth { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
    }
}
