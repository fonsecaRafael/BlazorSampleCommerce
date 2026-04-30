namespace BlazorSampleCommerce.DTOs
{
    public class SkuDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Dictionary<string, string> Features { get; set; } = new();
    }
}
