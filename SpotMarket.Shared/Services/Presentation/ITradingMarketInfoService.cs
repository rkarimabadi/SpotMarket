using SpotMarket.Shared.Models.Presentation;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface ITradingMarketInfoService
    {
        Task<List<TradingMarketInfo>> GetAllMarketsAsync(CancellationToken ct = default);
        Task<TradingHallHeaderData?> GetHeaderDataAsync(int marketId, CancellationToken ct = default);
        Task<HallStatusData?> GetStatusDataAsync(int marketId, CancellationToken ct = default);
        Task<DailyHighlightsData?> GetHighlightsDataAsync(int marketId, CancellationToken ct = default);
        Task<List<OfferListItem>> GetTradedOffersAsync(int marketId, CancellationToken ct = default);
        Task<List<OfferListItem>> GetUntradedOffersAsync(int marketId, CancellationToken ct = default);
        Task<List<OfferListItem>> GetFailedOffersAsync(int marketId, CancellationToken ct = default);
    }
}
