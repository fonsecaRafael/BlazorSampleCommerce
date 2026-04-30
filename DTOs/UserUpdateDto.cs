namespace BlazorSampleCommerce.DTOs
{
    public class UserUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Seller { get; set; }
        public string? Iva { get; set; }
        public string? TradingName { get; set; }
    }
}
