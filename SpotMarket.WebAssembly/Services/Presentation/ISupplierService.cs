using SpotMarket.WebAssembly.Models.Presentation;

namespace SpotMarket.WebAssembly.Services.Presentation
{
    public interface ISupplierService
    {
        Task<SupplierHeaderData?> GetSupplierHeaderAsync(int supplierId);
        Task<List<HierarchyItem>?> GetSupplierHierarchyAsync(int supplierId);
        Task<List<RankingItem>?> GetSupplierRankingAsync(int supplierId);
        Task<IEnumerable<MainPlayer>?> GetMainPlayersAsync(int supplierId);
        Task<List<CommodityGroupShareItem>?> GetMarketShareAsync(int supplierId);
        Task<CompetitionData?> GetCompetitionRatioAsync(int supplierId);
        Task<SeasonalActivityData?> GetSeasonalActivityAsync(int supplierId);
    }
}
