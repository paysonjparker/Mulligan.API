using System.Diagnostics.CodeAnalysis;

namespace Mulligan.API.Models.Requests.GolfCourseRequests
{
    [ExcludeFromCodeCoverage]
    public class UpdateGolfCourseRequest
    {
        public string? Name { get; set; }
        public string City { get; set; }
        public string? Subdivision { get; set; }
        public string? Country { get; set; }
        public int? Yardage { get; set; }
        public int? Par { get; set; }
        public int? SlopeRating { get; set; }
        public float? CourseRating { get; set; }
    }
}
