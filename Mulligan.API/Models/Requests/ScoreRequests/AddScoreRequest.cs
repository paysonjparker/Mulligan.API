using System.ComponentModel.DataAnnotations;

namespace Mulligan.API.Models.Requests.ScoreRequests
{
    public class AddScoreRequest
    {
        [Required]
        public int Total { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid GolfCourseId { get; set; }
    }
}
