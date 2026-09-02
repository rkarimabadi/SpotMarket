# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

"کالانما" — a Persian (RTL), mobile-first Blazor client for analytics on the Iran Mercantile Exchange (IME) physical spot market. It is a **pure presentation client**: it renders view-models fetched from a remote API (`https://spotapi.imedata.ir`), and contains no domain calculation logic. All indicators (market pulse, sentiment, excitement, supply risk, …) are computed server-side; the UI only formats and displays them. See `README.md` (Persian) for the analytical thinking behind each widget — it is the product spec.

## Build & run

```bash
dotnet build SpotMarket.sln
```

Run the web (PWA) client — this is the normal dev loop:

```bash
dotnet run --project SpotMarket.WebAssembly/SpotMarket.WebAssembly.csproj
```

Serves at `https://localhost:7109` / `http://localhost:5213`. VS Code has this as the task "Run SpotMarket.WebAssembly (dev)".

Mobile (MAUI, needs workloads; Android/iOS/MacCatalyst/Windows):

```bash
dotnet build SpotMarket.MobileApp/SpotMarket.MobileApp.csproj -f net9.0-android
```

There are no tests, no linter, and no CI in this repo.

### Pointing at a local API

Edit `SpotMarket.WebAssembly/wwwroot/appsettings.json` → `ApiSettings:BaseUrl` (a commented-out `https://localhost:7157` entry is already there). `AddPresentationServices` falls back to the production URL when the key is missing, so a bad key fails silently against prod rather than erroring.

## Architecture

Three projects, .NET 9:

- **`SpotMarket.Shared`** — a Razor Class Library holding *everything*: pages, routes, layout, widgets, models, services, CSS, JS, fonts. Nearly all work happens here.
- **`SpotMarket.WebAssembly`** — Blazor WASM host + PWA (service worker, manifest). Only `Program.cs`, `index.html`, `appsettings.json`.
- **`SpotMarket.MobileApp`** — .NET MAUI Blazor Hybrid host wrapping the same components in a `BlazorWebView`.

Both hosts do the same three things: call `builder.Services.AddPresentationServices(builder.Configuration)`, mount `SpotMarket.Shared.Routes` (which sets `MainLayout` as default layout and scans `typeof(MainLayout).Assembly` for `@page` routes), and load the shared CSS/JS from `_content/SpotMarket.Shared/`. **A new page added to `SpotMarket.Shared/Pages` is automatically routable in both hosts** — no host-side registration.

### Service layer

`Services/Presentation/*` — one typed `HttpClient` service per API controller, all registered in `Extensions/ServiceCollectionExtensions.cs` via `AddHttpClient<IFoo, Foo>`. The pattern is rigid and worth copying exactly: interface + impl in one file (or an `IFoo.cs` pair), a `_controllerPath` field like `"/api/dashboard"`, and one `GetFromJsonAsync<T>` per endpoint with a trailing `CancellationToken ct = default`. Adding an endpoint means adding a method here plus a DTO in `Models/Presentation`; adding a service also means a line in `ServiceCollectionExtensions`.

`ChatService` is the one exception to the read-a-view-model shape: `/api/chat/stream` is Server-Sent Events, consumed as an `IAsyncEnumerable<ChatStreamEvent>`. It opts into browser response streaming by setting the `WebAssemblyEnableStreamingResponse` request option directly (rather than referencing the WASM-only extension method), so the RCL stays host-agnostic — without it the browser buffers the whole response and the answer arrives all at once. Assistant replies are Markdown and may embed a ```chart JSON block; `Helpers/ChatMarkdown.cs` HTML-encodes first and then applies a limited Markdown subset, because the model's output can echo third-party text from database records.

`Services/App/*` — client-only state, registered `Scoped`:
- `SettingsService` — persists `UserSettings` (dashboard widget order/visibility, market page layout) to `localStorage` under key `userAppSettings` via JS interop. `GetDefaultSettings()` is the source of truth for the default dashboard; a new dashboard widget must be added to the `DashboardWidgetType` enum, its display name in `DashboardConfig.GetDisplayName()`, the defaults list here, and the `switch` in `Pages/Dashboard/Dashboard.razor`.
- `ChatHistoryService` — keeps the chat transcript in `localStorage` under `chatHistory`; the chat API is stateless, so the client resends history on every turn.
- `NavStateService` — pages push their title/back-button state (`NavState.SetNavState(title, showBackButton, backUrl)`) from `OnInitializedAsync`; `TopNav` subscribes to `OnStateChange`.

### Models

`Models/Presentation` are API view-models, deliberately shaped for a specific widget (e.g. `MarketPulse.cs` → `MarketPulseData`/`PulseCardItem`). They are not a domain model — do not try to unify them. `Models/App` are local settings/UI models.

### Widget component convention

Every data widget follows the same four-state shape, and new widgets should match it:

1. `@inject <IService>` + `@implements IDisposable`, with a private `CancellationTokenSource _cts`.
2. `OnInitializedAsync` sets `_isLoading`, calls the service with `_cts.Token`, catches `Exception` into `_hasError`, clears loading in `finally`.
3. Markup is an `@if (_isLoading) / else if (_hasError) / else if (data has rows) / else` chain rendering `<BarLoader />`, `<HasError />`, the real content, and `<NoData />` respectively — the outer `widget-container` / `section-header` chrome is repeated in each branch on purpose.
4. `Dispose()` cancels and disposes the CTS.

Shared state components (`Layout/Components`): `ToastContainer` and `GenericModalContainer` are instantiated once in `MainLayout` and passed down as `CascadingValue`s; take them with `[CascadingParameter]` and call `ShowToast(message, ToastType)` rather than building your own.

### Styling & assets

- Scoped CSS per component (`Foo.razor` + `Foo.razor.css`) is used almost everywhere. Global tokens live in `SpotMarket.Shared/wwwroot/css/app.css` as CSS custom properties on `:root` (`--primary-color`, the `--gray-*` ramp, `--mood-*`, `--risk-color-*`, `--safe-area-inset-*`, `--bottom-nav-height`). Use these variables, not literals.
- RTL: hosts set `<html dir="rtl" lang="fa">` and load `bootstrap.rtl.min.css`; the Peyda font (Farsi numerals variant) is bundled.
- JS lives in `SpotMarket.Shared/wwwroot/js` and is served at `_content/SpotMarket.Shared/js/...`. `chart-utility.js` (ES module; `renderChatChart`/`destroyChart`, used only by the chat). It lazy-loads the bundled `chart.js` on the first chart instead of the hosts script-tagging it, so the 208KB library never loads outside `/chat`. `toast.js`, `modal.js`, `jalaali.js`, `dataStorage.js`, `content-loaded.js` (`setupResizeObserver`/`getElementHeight`, used by `MainLayout` to size top-nav padding). Note the existing `InvokeAsync<IJSObjectReference>("import", "js/toast.js")` calls use a bare `js/…` path while the assets are only published under `_content/SpotMarket.Shared/js/…` — prefer the `_content/` path for new imports.

### Persian dates

`Helpers/PersianDateHelper.cs` (extension methods on `string`/`DateTime`) handles Jalali conversion and display formatting. API payloads carry Persian date strings like `yyyy/MM/dd`; convert with `.GetGregorian()` rather than parsing inline.

## Conventions

- UI strings, comments and XML docs are in Persian; identifiers are English. Keep this split.
- Files are UTF-8 with BOM and CRLF (`.gitattributes`); don't rewrite line endings wholesale.
- Nullable reference types and implicit usings are on in all three projects. Common namespaces are already in `SpotMarket.Shared/_Imports.razor` — new `Models.*`/`Services.*` sub-namespaces should be added there instead of per-file `@using`.
