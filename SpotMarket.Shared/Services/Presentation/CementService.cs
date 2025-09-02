using SpotMarket.Shared.Models.Presentation;
using System.Net.Http.Json;

namespace SpotMarket.Shared.Services.Presentation
{
    public class CementService : ICementService
    {
        private readonly HttpClient _httpClient;
        private readonly string _controllerPath = "/api/Broker";
        private readonly Dictionary<string, string> _cementTypeOptions = new()
        {
            {"PCT", "سیمان پرتلند"},
            {"PPC", "سیمان پوزولانی"},
            {"CPC", "سیمان مرکب"},
            {"WPC", "سیمان پرتلند سفید"},
            {"SAS", "سیمان ضد سولفات"},
            {"CEMENT", "سیمان"},
            {"SPC", "سیمان سرباره‌ای"},
            {"SP", "ویژه"}
        };
        private readonly Dictionary<string, string> _packagingOptions = new()
        {
            {"L", "کیسه"},
            {"B", "فله"},
            {"J", "جامبوبگ"}
        };
        private readonly Dictionary<string, string> _gradeOptions = new()
        {
            {"22.5", "رده 22.5"},
            {"32.5", "رده 32.5"},
            {"42.5", "رده 42.5"},
            {"52.5", "رده 52.5"},
            {"AN", "تا 20% عادی"},
            {"BN", "20 تا 35% عادی"},
            {"BR", "20 تا 35% سریع"},
            {"AR", "تا 20% سریع"},
            {"LA", "کم قلیا"}
        };
        public CementService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CementGroupsData> GetCementGroupsDataAsync()
        {
            await Task.Delay(500); // شبیه‌سازی تأخیر شبکه

            return new CementGroupsData
            {
                ActiveGroups = new List<CementGroupStatusItem>
                {
                    new() { Name = "سیمان پرتلند تیپ ۲", Subtitle = "سیمان تهران، سیمان آبیک", UrlName = "/cement/type-2", Status = GroupActivityStatus.HasOfferToday, OfferCount = 8, DemandStatus = DemandStatus.High },
                    new() { Name = "سیمان پرتلند تیپ ۱", Subtitle = "سیمان سپاهان، سیمان ساوه", UrlName = "/cement/type-1", Status = GroupActivityStatus.HasUpcomingOffer, OfferCount = 3, DemandStatus = DemandStatus.Medium },
                    new() { Name = "سیمان سفید پرتلند", Subtitle = "سیمان سفید شرق", UrlName = "/cement/white", Status = GroupActivityStatus.HasUpcomingOffer, OfferCount = 1, DemandStatus = DemandStatus.Low }
                },
                InactiveGroups = new List<CementGroupStatusItem>
                {
                    new() { Name = "سیمان پوزولانی", UrlName = "/cement/pozzolana", Status = GroupActivityStatus.Inactive, OfferCount = 0 },
                    new() { Name = "سیمان سرباره‌ای", UrlName = "/cement/slag", Status = GroupActivityStatus.Inactive, OfferCount = 0 },
                    new() { Name = "سیمان مرکب", UrlName = "/cement/composite", Status = GroupActivityStatus.Inactive, OfferCount = 0 }
                }
            };
        }
        public async Task<CementQuickPathData> GetCementQuickPathDataAsync()
        {
            await Task.Delay(500); // شبیه‌سازی تأخیر شبکه

            return new CementQuickPathData
            {
                Items = new List<QuickPathItem>
                {
                    new() { Title = "تیپ ۲ پاکتی", UrlName = "/cement/type-2/bagged", IconCssClass = "bi bi-bag-fill", ThemeCssClass = "theme-blue" },
                    new() { Title = "تیپ ۱ فله", UrlName = "/cement/type-1/bulk", IconCssClass = "bi bi-truck", ThemeCssClass = "theme-green" },
                    new() { Title = "سیمان سفید", UrlName = "/cement/white", IconCssClass = "bi bi-palette-fill", ThemeCssClass = "theme-purple" },
                    new() { Title = "جامبوبگ", UrlName = "/cement/jumbobag", IconCssClass = "bi bi-box-fill", ThemeCssClass = "theme-orange" }
                }
            };
        }
        public async Task<BasicCementMarketSummary> GetBasicCementMarketSummaryDataAsync()
        {
            await Task.Delay(500); // شبیه‌سازی تأخیر شبکه

            return new BasicCementMarketSummary
            {
                Value = "۸۵.۲ همت",
                Label = "ارزش کل معاملات امروز",
                Subtitle = "با میانگین رقابت +۲.۱٪",
            };
        }
        public async Task<CementMarketSummary> GetCementMarketSummaryDataAsync()
        {
            await Task.Delay(500); // شبیه‌سازی تأخیر شبکه

            return new CementMarketSummary
            {
                TotalValue = "۱۲۵.۳",
                TotalVolume = "۱۵۰ هزار تن",
                TodayOffersCount = 42,
                CompetitionValue = "+۱۰.۵٪",
                CompetitionPercentage = 0.75, // 75%
                DemandValue = "۲.۴x",
                DemandPercentage = 0.8, // 80%
                IsPositive = true
            };
        }

        public async Task<QuickPathPageData> GetQuickPathPageDataAsync(string urlName)
        {
            await Task.Delay(800); // شبیه سازی تاخیر شبکه

            var data = new QuickPathPageData();

            // All available options
            var cementTypes = new List<FilterOption>();
            foreach (var item in _cementTypeOptions)
            {
                cementTypes.Add(new FilterOption(item.Value, item.Key, item.Value, false));
            }

            var packagingOptions = new List<FilterOption>();
            foreach (var item in _packagingOptions)
            {
                packagingOptions.Add(new FilterOption(item.Value, item.Key, item.Value, false));
            }

            var gradeOptions = new List<FilterOption>();
            foreach (var item in _gradeOptions)
            {
                gradeOptions.Add(new FilterOption(item.Value, item.Key, item.Value, false));
            }

            var typeOptions = new List<FilterOption>();
            for (int i = 1; i <= 5; i++)
            {
                typeOptions.Add(new FilterOption($"تیپ {i}", i.ToString(), $"تیپ {i}", false));
            }

            switch (urlName)
            {
                case "type-2-bagged":
                    data.PageTitle = "سیمان پرتلند تیپ ۲ پاکتی";
                    data.ActiveFilters = new List<ActiveFilter>
                    {
                        new()
                        {
                            Title = "نوع سیمان",
                            Value = "سیمان پرتلند",
                            IconCssClass = "bi bi-journal-check",
                            Options = cementTypes
                        },
                        new()
                        {
                            Title = "تیپ",
                            Value = "تیپ ۲",
                            IconCssClass = "bi bi-journal",
                            Options = typeOptions
                        },
                        new()
                        {
                            Title = "بسته‌بندی",
                            Value = "کیسه",
                            IconCssClass = "bi bi-bag-fill",
                            Options = packagingOptions
                        },
                         new()
                         {
                            Title = "گرید",
                            Value = "رده ۴۲.۵",
                            IconCssClass = "bi bi-journal-plus",
                            Options = gradeOptions
                         }
                    };
                    data.Specifications = new List<TechnicalSpecification>
                    {
                        new() { Title = "مقاومت", Value = "رده ۴۲.۵", Interpretation = "مقاومت فشاری بالا و مناسب برای سازه‌های سنگین.", IconCssClass = "bi bi-lightning-charge", ThemeCssClass = "theme-red" },
                        new() { Title = "تسویه", Value = "نقدی", Interpretation = "تسویه به صورت نقدی انجام می‌شود.", IconCssClass = "bi bi-credit-card-2-front", ThemeCssClass = "theme-green" },
                        new() { Title = "حمل و نقل", Value = "فله/پاکتی", Interpretation = "امکان تحویل به صورت فله یا پاکتی وجود دارد.", IconCssClass = "bi bi-truck", ThemeCssClass = "theme-blue" },
                        new() { Title = "ضریب تقاضا", Value = "۱.۲x", Interpretation = "تقاضا ۱.۲ برابر عرضه است.", IconCssClass = "bi bi-people", ThemeCssClass = "theme-orange" }
                    };
                    data.PriceTrend = new PriceTrendData
                    {
                        Title = "روند قیمتی 10 عرضه اخیر",
                        PriceHistory = new List<PricePoint>
                        {
                            new() { DateLabel = "1 تیر", Price = 800000 },
                            new() { DateLabel = "7 تیر", Price = 820000 },
                            new() { DateLabel = "14 تیر", Price = 810000 },
                            new() { DateLabel = "21 تیر", Price = 850000 },
                            new() { DateLabel = "28 تیر", Price = 845000 },
                            new() { DateLabel = "30 تیر", Price = 800000 },
                            new() { DateLabel = "5 مرداد", Price = 720000 },
                            new() { DateLabel = "12 مرداد", Price = 750000 },
                            new() { DateLabel = "20 مرداد", Price = 650000 },
                            new() { DateLabel = "25 مرداد", Price = 745000 }
                        }
                    };
                    data.MainSuppliers = new List<MainSupplier>
                    {
                        new() { SupplierName = "سیمان تهران", LastTradePrice = 850000, OfferedVolume = 25000 },
                        new() { SupplierName = "سیمان آبیک", LastTradePrice = 845000, OfferedVolume = 18000 },
                        new() { SupplierName = "سیمان ممتازان", LastTradePrice = 860000, OfferedVolume = 12000 }
                    };
                    data.UpcomingOffers = new List<UpcomingOffer>
                    {
                        new() { Date = "۲۵", DayOfWeek = "شنبه", SupplierName = "سیمان تهران", Volume = "۵۰۰ تن", Price = "۱,۸۴۰,۰۰۰" , UrlName = "/offer/12345"},
                        new() { Date = "۲۷", DayOfWeek = "دوشنبه", SupplierName = "سیمان ممتازان", Volume = "۲۵۰ تن", Price = "۱,۸۵۵,۰۰۰", UrlName = "/offer/12346" },
                        new() { Date = "۲۸", DayOfWeek = "سه‌شنبه", SupplierName = "سیمان تهران", Volume = "۱,۰۰۰ تن", Price = "۱,۸۴۲,۰۰۰", UrlName = "/offer/12347" }
                    };
                    break;
                case "type-1-bulk":
                    data.PageTitle = "سیمان پرتلند تیپ ۱ فله";
                    data.ActiveFilters = new List<ActiveFilter>
                    {
                        new()
                        {
                            Title = "نوع سیمان",
                            Value = "سیمان پرتلند",
                            IconCssClass = "bi bi-journal-check",
                            Options = cementTypes
                        },
                        new()
                        {
                            Title = "تیپ",
                            Value = "تیپ ۱",
                            IconCssClass = "bi bi-journal",
                            Options = typeOptions
                        },
                        new()
                        {
                            Title = "بسته‌بندی",
                            Value = "فله",
                            IconCssClass = "bi bi-truck",
                            Options = packagingOptions
                        },
                        new()
                        {
                           Title = "گرید",
                           Value = "رده ۳۲.۵",
                           IconCssClass = "bi bi-journal-plus",
                           Options = gradeOptions
                        }
                    };
                    data.Specifications = new List<TechnicalSpecification>
                    {
                        new() { Title = "مقاومت", Value = "رده ۳۲.۵", Interpretation = "مقاومت فشاری استاندارد و مناسب برای سازه‌های عمومی.", IconCssClass = "bi bi-arrow-up-right-square", ThemeCssClass = "theme-blue" },
                        new() { Title = "تسویه", Value = "نسیه", Interpretation = "امکان تسویه در آینده وجود دارد.", IconCssClass = "bi bi-clock", ThemeCssClass = "theme-red" },
                        new() { Title = "حمل و نقل", Value = "فله", Interpretation = "تحویل به صورت فله از طریق بونکر.", IconCssClass = "bi bi-truck-flatbed", ThemeCssClass = "theme-green" },
                        new() { Title = "ضریب تقاضا", Value = "۰.۹x", Interpretation = "تقاضا کمی کمتر از عرضه است.", IconCssClass = "bi bi-people", ThemeCssClass = "theme-orange" }
                    };
                    data.PriceTrend = new PriceTrendData
                    {
                        Title = "روند قیمتی (۳۰ روز اخیر)",
                        PriceHistory = new List<PricePoint>
                        {
                            new() { DateLabel = "1 تیر", Price = 750000 },
                            new() { DateLabel = "7 تیر", Price = 760000 },
                            new() { DateLabel = "14 تیر", Price = 755000 },
                            new() { DateLabel = "21 تیر", Price = 780000 },
                            new() { DateLabel = "28 تیر", Price = 770000 }
                        }
                    };
                    data.MainSuppliers = new List<MainSupplier>
                    {
                        new() { SupplierName = "سیمان سپاهان", LastTradePrice = 770000, OfferedVolume = 30000 },
                        new() { SupplierName = "سیمان ساوه", LastTradePrice = 775000, OfferedVolume = 22000 },
                        new() { SupplierName = "سیمان شرق", LastTradePrice = 765000, OfferedVolume = 15000 }
                    };
                    data.UpcomingOffers = new List<UpcomingOffer>
                    {
                        new() { Date = "۲۶", DayOfWeek = "یک‌شنبه", SupplierName = "سیمان ساوه", Volume = "۸۰۰ تن", Price = "۱,۷۶۵,۰۰۰" , UrlName = "/offer/12348"},
                        new() { Date = "۲۹", DayOfWeek = "چهارشنبه", SupplierName = "سیمان سپاهان", Volume = "۱,۲۰۰ تن", Price = "۱,۷۷۵,۰۰۰", UrlName = "/offer/12349" },
                        new() { Date = "۳۰", DayOfWeek = "پنجشنبه", SupplierName = "سیمان شرق", Volume = "۷۰۰ تن", Price = "۱,۷۶۰,۰۰۰", UrlName = "/offer/12350" }
                    };
                    break;
                case "white":
                    data.PageTitle = "سیمان سفید";
                    data.ActiveFilters = new List<ActiveFilter>
                    {
                        new()
                        {
                            Title = "نوع سیمان",
                            Value = "سیمان پرتلند سفید",
                            IconCssClass = "bi bi-journal-check",
                            Options = cementTypes
                        },
                        new()
                        {
                           Title = "گرید",
                           Value = "رده ۵۲.۵",
                           IconCssClass = "bi bi-journal-plus",
                           Options = gradeOptions
                        },
                        new()
                        {
                            Title = "بسته‌بندی",
                            Value = "کیسه",
                            IconCssClass = "bi bi-bag",
                            Options = packagingOptions
                        }
                    };
                    data.Specifications = new List<TechnicalSpecification>
                    {
                        new() { Title = "مقاومت", Value = "رده ۵۲.۵", Interpretation = "مقاومت بسیار بالا و مناسب برای مصارف تزئینی و ساختمانی.", IconCssClass = "bi bi-award", ThemeCssClass = "theme-blue" },
                        new() { Title = "تسویه", Value = "نقدی", Interpretation = "تسویه به صورت نقدی انجام می‌شود.", IconCssClass = "bi bi-credit-card-2-front", ThemeCssClass = "theme-green" },
                        new() { Title = "حمل و نقل", Value = "پاکتی", Interpretation = "تحویل به صورت پاکت‌های ۵۰ کیلویی.", IconCssClass = "bi bi-bag", ThemeCssClass = "theme-orange" },
                        new() { Title = "ضریب تقاضا", Value = "۱.۸x", Interpretation = "تقاضا برای این محصول بسیار بالاست.", IconCssClass = "bi bi-people", ThemeCssClass = "theme-red" }
                    };
                    data.PriceTrend = new PriceTrendData
                    {
                        Title = "روند قیمتی (۳۰ روز اخیر)",
                        PriceHistory = new List<PricePoint>
                        {
                            new() { DateLabel = "1 تیر", Price = 1200000 },
                            new() { DateLabel = "7 تیر", Price = 1250000 },
                            new() { DateLabel = "14 تیر", Price = 1240000 },
                            new() { DateLabel = "21 تیر", Price = 1280000 },
                            new() { DateLabel = "28 تیر", Price = 1270000 }
                        }
                    };
                    data.MainSuppliers = new List<MainSupplier>
                    {
                        new() { SupplierName = "سیمان سفید شرق", LastTradePrice = 1270000, OfferedVolume = 8000 },
                        new() { SupplierName = "سیمان سفید بنوید", LastTradePrice = 1265000, OfferedVolume = 6000 },
                        new() { SupplierName = "سیمان سفید ارومیه", LastTradePrice = 1280000, OfferedVolume = 5000 }
                    };
                    data.UpcomingOffers = new List<UpcomingOffer>
                    {
                        new() { Date = "۲۷", DayOfWeek = "دوشنبه", SupplierName = "سیمان سفید شرق", Volume = "۱۰۰ تن", Price = "۲,۷۶۵,۰۰۰" , UrlName = "/offer/12351"},
                        new() { Date = "۲۹", DayOfWeek = "چهارشنبه", SupplierName = "سیمان سفید بنوید", Volume = "۱۵۰ تن", Price = "۲,۷۷۵,۰۰۰", UrlName = "/offer/12352" },
                        new() { Date = "۳۰", DayOfWeek = "پنجشنبه", SupplierName = "سیمان سفید شرق", Volume = "۸۰ تن", Price = "۲,۷۸۰,۰۰۰", UrlName = "/offer/12353" }
                    };
                    break;
                case "jumbobag":
                    data.PageTitle = "سیمان جامبوبگ";
                    data.ActiveFilters = new List<ActiveFilter>
                    {
                        new()
                        {
                            Title = "نوع سیمان",
                            Value = "سیمان",
                            IconCssClass = "bi bi-journal-check",
                            Options = cementTypes
                        },
                        new()
                        {
                            Title = "بسته‌بندی",
                            Value = "جامبوبگ",
                            IconCssClass = "bi bi-box-fill",
                            Options = packagingOptions
                        },
                         new()
                         {
                            Title = "گرید",
                            Value = "رده ۴۲.۵",
                            IconCssClass = "bi bi-journal-plus",
                            Options = gradeOptions
                         }
                    };
                    data.Specifications = new List<TechnicalSpecification>
                    {
                        new() { Title = "مقاومت", Value = "رده ۴۲.۵", Interpretation = "مقاومت فشاری بالا و مناسب برای سازه‌های سنگین.", IconCssClass = "bi bi-lightning-charge", ThemeCssClass = "theme-blue" },
                        new() { Title = "تسویه", Value = "نقدی", Interpretation = "تسویه به صورت نقدی انجام می‌شود.", IconCssClass = "bi bi-credit-card-2-front", ThemeCssClass = "theme-green" },
                        new() { Title = "حمل و نقل", Value = "جامبوبگ", Interpretation = "تحویل به صورت کیسه‌های بزرگ.", IconCssClass = "bi bi-box-fill", ThemeCssClass = "theme-orange" },
                        new() { Title = "ضریب تقاضا", Value = "۱.۴x", Interpretation = "تقاضا برای این محصول بالاست.", IconCssClass = "bi bi-people", ThemeCssClass = "theme-red" }
                    };
                    data.PriceTrend = new PriceTrendData
                    {
                        Title = "روند قیمتی (۳۰ روز اخیر)",
                        PriceHistory = new List<PricePoint>
                        {
                            new() { DateLabel = "1 تیر", Price = 950000 },
                            new() { DateLabel = "7 تیر", Price = 960000 },
                            new() { DateLabel = "14 تیر", Price = 945000 },
                            new() { DateLabel = "21 تیر", Price = 980000 },
                            new() { DateLabel = "28 تیر", Price = 975000 }
                        }
                    };
                    data.MainSuppliers = new List<MainSupplier>
                    {
                        new() { SupplierName = "سیمان خوزستان", LastTradePrice = 975000, OfferedVolume = 15000 },
                        new() { SupplierName = "سیمان آباده", LastTradePrice = 970000, OfferedVolume = 10000 },
                        new() { SupplierName = "سیمان تجارت مهریز", LastTradePrice = 985000, OfferedVolume = 7000 }
                    };
                    data.UpcomingOffers = new List<UpcomingOffer>
                    {
                        new() { Date = "۲۶", DayOfWeek = "یک‌شنبه", SupplierName = "سیمان خوزستان", Volume = "۶۰۰ تن", Price = "۲,۲۲۰,۰۰۰" , UrlName = "/offer/12354"},
                        new() { Date = "۲۹", DayOfWeek = "چهارشنبه", SupplierName = "سیمان آباده", Volume = "۸۰۰ تن", Price = "۲,۲۳۵,۰۰۰", UrlName = "/offer/12355" },
                        new() { Date = "۳۰", DayOfWeek = "پنجشنبه", SupplierName = "سیمان خوزستان", Volume = "۴۵۰ تن", Price = "۲,۲۴۰,۰۰۰", UrlName = "/offer/12356" }
                    };
                    break;
                default:
                    data.PageTitle = "محصول نامشخص";
                    break;
            }
            return data;
        }
    }
}
