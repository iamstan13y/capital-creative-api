namespace CapitalCreative.API.Models.Local
{
    public class ProductRequest
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
    }
}