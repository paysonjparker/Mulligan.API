using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mulligan.API.Models.Domain
{
    [ExcludeFromCodeCoverage]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public float HandicapIndex { get; set; }
        public string? HomeCourseName { get; set; }
        public ICollection<Score>? Scores { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public Guid? GolfCourseId { get; set; }
        public GolfCourse? GolfCourse { get; set; }
    }
}
