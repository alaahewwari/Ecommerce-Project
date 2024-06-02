namespace ECommerceAPI.Dtos.Product.Requests
{
    public record ProductRequestDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public int StockQuantity { get; set; }
        public string Description { get; set; }
        public long BrandId { get; set; }
        public long CategoryId { get; set; }
    }
}
