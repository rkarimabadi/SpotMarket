namespace SpotMarket.Shared.Helpers
{
    using System;
    using System.Globalization;

    public static class PersianDateHelper
    {
        /// <summary>
        /// یک رشته تاریخ شمسی با فرمت yyyy/MM/dd را به DateTime میلادی تبدیل می‌کند.
        /// </summary>
        public static DateTime GetGregorian(this string persianDate)
        {
            try
            {
                                var pc = new PersianCalendar();
                var parts = persianDate.Split('/');
                if (parts.Length != 3) return DateTime.MinValue;

                int year = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int day = int.Parse(parts[2]);

                return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        /// <summary>
        /// تاریخ فعلی را به فرمت زیبای فارسی برمی‌گرداند (مثال: چهارشنبه، ۸ مرداد)
        /// </summary>
        /// <returns>رشته تاریخ فرمت‌شده</returns>
        public static string GetFormattedPersianDate()
        {
            try
            {
                var today = DateTime.Now;
                var pc = new PersianCalendar();

                var dayOfWeekName = GetPersianDayOfWeek(pc.GetDayOfWeek(today));
                var dayOfMonth = pc.GetDayOfMonth(today);
                var monthName = GetPersianMonthName(pc.GetMonth(today));

                return $"{dayOfWeekName}، {dayOfMonth} {monthName}";
            }
            catch (Exception)
            {
                // در صورت بروز هرگونه خطا، یک مقدار پیش‌فرض برمی‌گرداند
                return "امروز";
            }
        }

        private static string GetPersianDayOfWeek(DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Saturday => "شنبه",
                DayOfWeek.Sunday => "یکشنبه",
                DayOfWeek.Monday => "دوشنبه",
                DayOfWeek.Tuesday => "سه‌شنبه",
                DayOfWeek.Wednesday => "چهارشنبه",
                DayOfWeek.Thursday => "پنج‌شنبه",
                DayOfWeek.Friday => "جمعه",
                _ => ""
            };
        }

        private static string GetPersianMonthName(int month)
        {
            return month switch
            {
                1 => "فروردین",
                2 => "اردیبهشت",
                3 => "خرداد",
                4 => "تیر",
                5 => "مرداد",
                6 => "شهریور",
                7 => "مهر",
                8 => "آبان",
                9 => "آذر",
                10 => "دی",
                11 => "بهمن",
                12 => "اسفند",
                _ => ""
            };
        }
    }

}
