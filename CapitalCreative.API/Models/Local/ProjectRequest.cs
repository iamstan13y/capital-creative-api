namespace CapitalCreative.API.Models.Local
{
    public class ProjectRequest
    {
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? ShortDescription { get; set; }
        public string? DetailedDescription { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime DateCommissioned { get; set; }
    }

    public class UpdateProjectRequest : ProjectRequest
    {
        public int Id { get; set; }
    }
}