using SpotMarket.Shared.Models.Presentation;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface ITradingMarketInfoService
    {
        Task<List<TradingMarketInfo>> GetAllMarketsAsync();
        Task<TradingHallHeaderData?> GetHeaderDataAsync(int marketId);
        Task<HallStatusData?> GetStatusDataAsync(int marketId);
        Task<DailyHighlightsData?> GetHighlightsDataAsync(int marketId);
        Task<List<OfferListItem>> GetTradedOffersAsync(int marketId);
        Task<List<OfferListItem>> GetUntradedOffersAsync(int marketId);
        Task<List<OfferListItem>> GetFailedOffersAsync(int marketId);
    }
}
