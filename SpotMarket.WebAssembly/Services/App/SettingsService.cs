using SpotMarket.WebAssembly.Models.App;
using Microsoft.JSInterop;
using System.Text.Json;
namespace SpotMarket.WebAssembly.Services.App
{
    public class SettingsService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string SettingsKey = "userAppSettings";

        public SettingsService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        /// <summary>
        /// تنظیمات کاربر را از LocalStorage بارگذاری می‌کند
        /// </summary>
        public async Task<UserSettings?> LoadSettingsAsync()
        {
            try
            {
                var settingsJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", SettingsKey);
                if (string.IsNullOrEmpty(settingsJson))
                {
                    return GetDefaultSettings();
                }
                return JsonSerializer.Deserialize<UserSettings>(settingsJson);
            }
            catch
            {
                return GetDefaultSettings();
            }
        }

        /// <summary>
        /// تنظیمات کاربر را در LocalStorage ذخیره می‌کند
        /// </summary>
        public async Task SaveSettingsAsync(UserSettings settings)
        {
            var settingsJson = JsonSerializer.Serialize(settings);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", SettingsKey, settingsJson);
        }

        /// <summary>
        /// تنظیمات پیش‌فرض برنامه را برمی‌گرداند
        /// </summary>
        public UserSettings GetDefaultSettings()
        {
            return new UserSettings
            {
                DashboardLayout = new List<DashboardWidgetConfig>
            {
                new() { Type = DashboardWidgetType.TradingHalls, IsVisible = true },
                new() { Type = DashboardWidgetType.MarketMovers, IsVisible = true },
                new() { Type = DashboardWidgetType.MainPlayers, IsVisible = true },
                new() { Type = DashboardWidgetType.MarketExcitement, IsVisible = true },
                new() { Type = DashboardWidgetType.MarketPulse, IsVisible = true },
                new() { Type = DashboardWidgetType.MarketSentiment, IsVisible = true },
                new() { Type = DashboardWidgetType.SupplyRisk, IsVisible = true },
                new() { Type = DashboardWidgetType.News, IsVisible = true }
            }
            };
        }
    }



}
