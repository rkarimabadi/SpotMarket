using Microsoft.Extensions.DependencyInjection;
using SpotMarket.WebAssembly.Services.Presentation;

namespace SpotMarket.WebAssembly.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var apiBaseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
            if (string.IsNullOrEmpty(apiBaseUrl))
            {
                throw new InvalidOperationException("آدرس پایه API در فایل تنظیمات مشخص نشده است.");
            }

            Action<HttpClient> configureClient = client => client.BaseAddress = new Uri(apiBaseUrl);

            services.AddHttpClient<IDashboardService, DashboardService>(configureClient);
            services.AddHttpClient<IMarketsService, MarketsService>(configureClient);
            services.AddHttpClient<IMainGroupService, MainGroupService>(configureClient);
            services.AddHttpClient<IGroupService, GroupService>(configureClient);
            services.AddHttpClient<ISubGroupService, SubGroupService>(configureClient);
            services.AddHttpClient<IOfferDetailsService, OfferDetailsService>(configureClient);
            services.AddHttpClient<ICommodityService, CommodityService>(configureClient);
            services.AddHttpClient<ISearchService, SearchService>(configureClient);
            services.AddHttpClient<IBrokerService, BrokerService>(configureClient);
            return services;
        }
    }
}
