using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpotMarket.WebAssembly;
using SpotMarket.WebAssembly.Services.App;
using SpotMarket.WebAssembly.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<SettingsService>();
builder.Services.AddScoped<NavStateService>();

builder.Services.AddPresentationServices(builder.Configuration);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();