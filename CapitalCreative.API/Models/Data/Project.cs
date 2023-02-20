namespace CapitalCreative.API.Models.Data
{
    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
    }
}