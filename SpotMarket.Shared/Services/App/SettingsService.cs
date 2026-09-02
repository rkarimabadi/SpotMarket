using Microsoft.JSInterop;
using System.Text.Json;
using SpotMarket.Shared.Models.App;
namespace SpotMarket.Shared.Services.App
{
    public class SettingsService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string SettingsKey = "userAppSettings";

        public SettingsService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<UserSettings?> LoadSettingsAsync(CancellationToken ct = default)
        {
            try
            {
                var settingsJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", ct, SettingsKey);
                if (string.IsNullOrEmpty(settingsJson))
                {
                    return GetDefaultSettings();
                }
                var settings = JsonSerializer.Deserialize<UserSettings>(settingsJson);
                if (settings is null) return GetDefaultSettings();

                MergeNewWidgets(settings);
                return settings;
            }
            catch
            {
                return GetDefaultSettings();
            }
        }

        public async Task SaveSettingsAsync(UserSettings settings, CancellationToken ct = default)
        {
            var settingsJson = JsonSerializer.Serialize(settings);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", ct, SettingsKey, settingsJson);
        }

        /// <summary>
        /// ویجت‌هایی را که پس از ذخیره شدن تنظیمات کاربر به برنامه اضافه شده‌اند، در جای
        /// پیش‌فرضشان به چیدمان او اضافه می‌کند.
        ///
        /// بدون این کار، کاربری که یک بار وارد صفحه تنظیمات شده هیچ‌وقت ویجت‌های جدید را
        /// نمی‌بیند، چون چیدمان ذخیره‌شده‌اش کامل و معتبر به نظر می‌رسد.
        /// </summary>
        private void MergeNewWidgets(UserSettings settings)
        {
            var defaults = GetDefaultSettings().DashboardLayout;

            for (var i = 0; i < defaults.Count; i++)
            {
                if (settings.DashboardLayout.Any(widget => widget.Type == defaults[i].Type)) continue;

                var position = Math.Min(i, settings.DashboardLayout.Count);
                settings.DashboardLayout.Insert(position, defaults[i]);
            }
        }

        public UserSettings GetDefaultSettings()
        {
            return new UserSettings
            {
                DashboardLayout = new List<DashboardWidgetConfig>
                {
                    new() { Type = DashboardWidgetType.MarketProgress, IsVisible = true },
                    new() { Type = DashboardWidgetType.ChatAssistant, IsVisible = true },
                    new() { Type = DashboardWidgetType.TradingHalls, IsVisible = true },
                    new() { Type = DashboardWidgetType.MarketMovers, IsVisible = true },
                    new() { Type = DashboardWidgetType.MainPlayers, IsVisible = true },
                    new() { Type = DashboardWidgetType.MarketExcitement, IsVisible = true },
                    new() { Type = DashboardWidgetType.MarketPulse, IsVisible = true },
                    new() { Type = DashboardWidgetType.MarketSentiment, IsVisible = true },
                    new() { Type = DashboardWidgetType.SupplyRisk, IsVisible = true },
                    new() { Type = DashboardWidgetType.SpotNotifictions, IsVisible = true }
                },
                MarketPageLayout = new MarketSettings
                {
                    MainView = MarketMainViewType.Shortcuts,
                    VisibleInfoWidgets = new List<MarketInfoWidgetType>
                    {
                        MarketInfoWidgetType.SelectedCommodity
                    }
                }
            };
        }
    }
}
