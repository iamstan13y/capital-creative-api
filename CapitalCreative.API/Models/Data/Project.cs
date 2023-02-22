namespace CapitalCreative.API.Models.Data
{
    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? ShortDescription { get; set; }
        public string? DetailedDescription { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime DateCommissioned { get; set; }
    }
}