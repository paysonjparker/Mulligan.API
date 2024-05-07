using System.ComponentModel.DataAnnotations;

namespace Mulligan.API.Models.Requests.UserRequests
{
    public class UpdateUserRequest
    {
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public float HandicapIndex { get; set; }
        [Required]
        public Guid GolfCourseId { get; set; }
    }
}
