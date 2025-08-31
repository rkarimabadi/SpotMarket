namespace SpotMarket.Shared.Models.Presentation
{
    // --- مدل‌های داده برای این کامپوننت ---
    public record CategorizedSubGroups(
        List<SubGroupItem> OnOfferToday,
        List<SubGroupItem> HottestDeals,
        List<SubGroupItem> UpcomingOffers,
        List<SubGroupItem> OtherGroups
    );

    public record SubGroupItem(
        string Title,
        string Subtitle,
        string Stat,
        string StatCssClass = ""
    );
}
