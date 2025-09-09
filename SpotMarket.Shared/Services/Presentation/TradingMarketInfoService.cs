using SpotMarket.Shared.Models.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SpotMarket.Shared.Services.Presentation
{
    public class TradingMarketInfoService : ITradingMarketInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/TradingMarketInfo";

        public TradingMarketInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task<List<TradingMarketInfo>> GetAllMarketsAsync()
        {
            // فراخوانی نقطه پایانی 'all' از کنترلر TradingMarketInfoController
            return await _httpClient.GetFromJsonAsync<List<TradingMarketInfo>>($"{_controllerPath}/all") ?? new List<TradingMarketInfo>();
        }
    }
}
