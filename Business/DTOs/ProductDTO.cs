namespace Business.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Descriptions { get; set; } = null!;
        public decimal? Cost { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public int UserId { get; set; }
    }
}
