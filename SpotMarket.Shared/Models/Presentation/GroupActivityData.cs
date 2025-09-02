using System.Collections.Generic;

namespace SpotMarket.Shared.Models.Presentation
{
    /// <summary>
    /// مدل داده برای ویجت "خلاصه فعالیت روزانه"
    /// </summary>
    public class GroupActivityData
    {
        /// <summary>
        /// مقدار شاخص رقابت (مثلا: "+۱۲.۵٪")
        /// </summary>
        public string CompetitionValue { get; set; } = string.Empty;

        /// <summary>
        /// درصد پیشرفت حلقه رقابت (بین 0.0 تا 1.0)
        /// </summary>
        public double CompetitionPercentage { get; set; }

        /// <summary>
        /// مقدار ضریب تقاضا (مثلا: "۲.۵x")
        /// </summary>
        public string DemandValue { get; set; } = string.Empty;

        /// <summary>
        /// درصد پیشرفت حلقه تقاضا (بین 0.0 تا 1.0)
        /// </summary>
        public double DemandPercentage { get; set; }

        /// <summary>
        /// ارزش کل معاملات
        /// </summary>
        public string TotalValue { get; set; } = string.Empty;

        /// <summary>
        /// حجم کل معاملات
        /// </summary>
        public string TotalVolume { get; set; } = string.Empty;
    }
}
