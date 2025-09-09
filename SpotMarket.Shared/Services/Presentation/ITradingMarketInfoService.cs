using SpotMarket.Shared.Models.Presentation;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface ITradingMarketInfoService
    {
        Task<List<TradingMarketInfo>> GetAllMarketsAsync();
    }
}
