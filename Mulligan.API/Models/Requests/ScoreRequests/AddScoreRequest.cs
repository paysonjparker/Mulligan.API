using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mulligan.API.Models.Requests.ScoreRequests
{
    [ExcludeFromCodeCoverage]
    public class AddScoreRequest
    {
        [Required]
        public int Total { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int GolfCourseId { get; set; }
    }
}
