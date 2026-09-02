using System.Text.RegularExpressions;

namespace SpotMarket.Shared.Helpers
{
    /// <summary>
    /// شرح توابع دستیار را برای نمایش به کاربر پاکیزه می‌کند.
    ///
    /// این شرح‌ها در سرور برای خود مدل زبانی نوشته شده‌اند، پس نام تابع، نام پارامتر و
    /// مقادیر مجاز را به انگلیسی در خود دارند (مثلاً entityType یا SubGroup یا false).
    /// در فهرست «دستیار به چه داده‌هایی دسترسی دارد» مخاطب کاربر فارسی‌زبان است و این
    /// واژه‌ها برای او معنایی ندارند.
    ///
    /// به‌جای حذف تک‌تک واژه‌ها — که جمله را ناقص و بی‌معنا می‌کند — جمله‌هایی که به
    /// انگلیسی آلوده‌اند به‌طور کامل کنار گذاشته می‌شوند؛ این جمله‌ها همیشه راهنمای
    /// فراخوانی تابع‌اند، نه توضیح داده‌ای که کاربر به آن نیاز دارد.
    /// </summary>
    public static class ChatToolDescription
    {
        /// <summary>پرانتزی که داخلش انگلیسی است، مثل «(brokerId را ابتدا از Search بگیر)».</summary>
        private static readonly Regex LatinParenthetical = new(@"\([^)]*[A-Za-z][^)]*\)", RegexOptions.Compiled);

        private static readonly Regex Latin = new("[A-Za-z]", RegexOptions.Compiled);

        /// <summary>
        /// مرز جمله. نقطه‌ای که خودش بخشی از «...» است مرز به حساب نمی‌آید تا فهرست‌های
        /// ناتمام مثل «(نقدی، سلف، نسیه و ...)» شکسته نشوند.
        /// </summary>
        private static readonly Regex SentenceBreak = new(@"(?<=(?<!\.)[.!؟])\s+", RegexOptions.Compiled);

        /// <summary>
        /// فاصله‌ی جامانده پیش از نقطه‌گذاری، بعد از حذف پرانتز. نقطه‌ای که آغاز «...»
        /// است استثناست تا «و ...» به «و...» تبدیل نشود.
        /// </summary>
        private static readonly Regex SpaceBeforePunctuation = new(@"\s+([،؛:!؟]|\.(?!\.))", RegexOptions.Compiled);

        private static readonly Regex RepeatedSpace = new(@"\s{2,}", RegexOptions.Compiled);

        public static string ForDisplay(string? description)
        {
            if (string.IsNullOrWhiteSpace(description)) return string.Empty;

            var text = LatinParenthetical.Replace(description, " ");

            var persianOnly = SentenceBreak.Split(text)
                .Where(sentence => !Latin.IsMatch(sentence));

            var result = string.Join(" ", persianOnly);
            result = SpaceBeforePunctuation.Replace(result, "$1");

            return RepeatedSpace.Replace(result, " ").Trim();
        }
    }
}
