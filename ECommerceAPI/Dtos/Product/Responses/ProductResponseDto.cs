namespace ECommerceAPI.Dtos.Product.Responses
{
    public class ProductResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public int StockQuantity { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public BrandResponseDto Brand { get; set; }
        public CategoryResponseDto Category { get; set; }
    }
}
