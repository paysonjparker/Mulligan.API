namespace Mulligan.API.Models.Requests.GolfCourseRequests
{
    public class SearchGolfCourseRequest
    {
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Subdivision { get; set; }
        public string? Country { get; set; }
    }
}
