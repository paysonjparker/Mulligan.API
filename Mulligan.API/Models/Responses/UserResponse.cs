using Mulligan.API.Models.Domain;

namespace Mulligan.API.Models.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public float HandicapIndex { get; set; }
        public string HomeCourseName { get; set; }
        public ICollection<ScoreDomain> Scores { get; set; }
        public ICollection<PostDomain> Posts { get; set; }
        public Guid GolfCourseId { get; set; }
    }
}
