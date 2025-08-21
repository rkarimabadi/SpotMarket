namespace SpotMarket.WebAssembly.Models.Presentation
{
    public class HierarchyItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public bool IsLast => !IsActive; // Simple logic for this example
    }
}
