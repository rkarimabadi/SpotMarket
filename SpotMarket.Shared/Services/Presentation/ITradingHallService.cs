using SpotMarket.Shared.Models.Presentation;
namespace SpotMarket.Shared.Services.Presentation
{
    public interface ITradingHallService
    {
        Task<TradingHallHeaderData?> GetHeaderDataAsync();
        Task<HallStatusData?> GetStatusDataAsync();
        Task<DailyHighlightsData?> GetHighlightsDataAsync();
    }
}
