namespace SpotMarket.WebAssembly.Models.Presentation
{
    public class MainPlayer
    {
        /// <summary>
        /// نوع بازیگر، مثلا: برترین کارگزار
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// نام بازیگر، مثلا: کارگزاری مفید
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// کلاس آیکون بوت‌استرپ برای نمایش
        /// </summary>
        public string IconCssClass { get; set; } = string.Empty;

        /// <summary>
        /// سهم از بازار به صورت درصد
        /// </summary>
        public decimal MarketShare { get; set; }
    }

}
