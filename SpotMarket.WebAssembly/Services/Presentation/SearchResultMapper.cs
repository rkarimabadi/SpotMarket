using SpotMarket.WebAssembly.Models.Presentation;

namespace SpotMarket.WebAssembly.Services.Presentation
{
    // OfferDataModels.cs

    public static class SearchResultMapper
        {
            /// <summary>
            /// مدل داده خام API را به مدل نمایشی مورد استفاده در UI تبدیل می‌کند.
            /// </summary>
            public static SearchResult ToViewModel(this SearchResultItem item)
            {
                var (icon, iconCssClass) = GetVisuals(item.ResultType);
                var navigationUrl = GetNavigationUrl(item.ResultType, item.Id);

                return new SearchResult(
                    item.Id,
                    item.Title,
                    item.Subtitle,
                    icon,
                    iconCssClass,
                    navigationUrl
                );
            }

            private static (string Icon, string IconCssClass) GetVisuals(SearchResultType type)
            {
                return type switch
                {
                    SearchResultType.Commodity => ("bi-box", "industrial"),
                    SearchResultType.SubGroup => ("bi-boxes", "industrial"),
                    SearchResultType.Group => ("bi-collection", "industrial"),
                    SearchResultType.MainGroup => ("bi-building", "industrial"),
                    SearchResultType.Broker => ("bi-person-workspace", "broker"),
                    SearchResultType.Supplier => ("bi-buildings-fill", "supplier"),
                    SearchResultType.Manufacturer => ("bi-industry", "supplier"),
                    _ => ("bi-question-circle", "secondary")
                };
            }

            private static string GetNavigationUrl(SearchResultType type, int id)
            {
                return type switch
                {
                    SearchResultType.Commodity => $"/commodity/{id}",
                    SearchResultType.Group => $"/groups/{id}",
                    SearchResultType.Broker => $"/players/brokers/{id}",
                    SearchResultType.Supplier => $"/players/suppliers/{id}",
                    _ => "#"
                };
            }
        }
}
