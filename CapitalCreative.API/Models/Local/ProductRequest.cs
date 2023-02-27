namespace CapitalCreative.API.Models.Local
{
    public class ProductRequest
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public double Price { get; set; }
    }

    public class UpdateProductRequest : ProductRequest
    {
        public int Id { get; set; }
    }
}