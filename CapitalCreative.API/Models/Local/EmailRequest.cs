namespace CapitalCreative.API.Models.Local
{
    public class EmailRequest
    {
        public string? To { get; set; }
        public string? From { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}