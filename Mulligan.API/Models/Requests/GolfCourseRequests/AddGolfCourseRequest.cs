using System.ComponentModel.DataAnnotations;

namespace Mulligan.API.Models.Requests.GolfCourseRequests
{
    public class AddGolfCourseRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int SlopeRating { get; set; }
        [Required]
        public float CourseRating { get; set; }
        [Required]
        public int Yardage { get; set; }
        [Required]
        public int Par { get; set; }
    }
}
