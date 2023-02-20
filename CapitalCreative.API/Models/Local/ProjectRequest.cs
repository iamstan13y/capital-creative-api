namespace CapitalCreative.API.Models.Local
{
    public class ProjectRequest
    {
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
    }

    public class UpdateProjectRequest : ProjectRequest
    {
        public int Id { get; set; }
    }
}