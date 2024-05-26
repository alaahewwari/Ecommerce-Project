namespace ECommerceAPI.Dtos.Product.Responses
{
    public class CreateProductResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public int StockQuantity { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
    }
}
