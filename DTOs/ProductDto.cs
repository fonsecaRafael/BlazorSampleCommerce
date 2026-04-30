namespace BlazorSampleCommerce.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Brand {get; set;} = string.Empty;
        public Guid SellerId { get; set; }
        public List<SkuDto> StockKeepingUnits { get; set; } = new();
    }
}
