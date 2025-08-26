namespace SpotMarket.WebAssembly.Models.Presentation
{
    public class RankingItem
    {
        public string Title { get; set; } = "";
        public string Subtitle { get; set; } = "";
        public int Rank { get; set; }
        public string IconCssClass { get; set; } = "";
        public string ThemeCssClass { get; set; } = "";
    }
}
