using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mulligan.API.Models.Domain
{
    [ExcludeFromCodeCoverage]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public float HandicapIndex { get; set; }
        public string? HomeCourseName { get; set; }
        public ICollection<Score>? Scores { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public int? GolfCourseId { get; set; }
        public GolfCourse? GolfCourse { get; set; }
    }
}
