namespace CapitalCreative.API.Models.Local
{
    public class QuoteRequest
    {
        public string? Address { get; set; }
        public List<string>? Appliances { get; set; }
        public double Budget { get; set; }
        public string? ChoosingTheRightSystem { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? HowDidYouHearAboutUs { get; set; }
        public string? OtherInformation { get; set; }
        public string? PhoneNumber { get; set; }
        public string? RoofPitchedOrFlat { get; set; }
        public string? RoofType { get; set; }
        public string? SystemRequirements { get; set; }
    }
}