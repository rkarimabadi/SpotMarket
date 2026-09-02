using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;

namespace SpotMarket.Shared.Services.Presentation
{
    public interface IOfferDetailsService
    {
        Task<OfferViewModel> GetOfferByIdAsync(int offerId, CancellationToken ct = default);
    }

    public class OfferDetailsService : IOfferDetailsService
    {
        private readonly string _controllerPath = "/api/OfferDetails";
        private readonly HttpClient _httpClient;

        public OfferDetailsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<OfferViewModel> GetOfferByIdAsync(int offerId, CancellationToken ct = default)
        {
            return await _httpClient.GetFromJsonAsync<OfferViewModel>($"{_controllerPath}/{offerId}", ct) ?? new OfferViewModel();
        }
    }
}
