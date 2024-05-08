using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mulligan.API.Models.Domain
{
    [ExcludeFromCodeCoverage]
    public class Score
    {
        [Key]
        public Guid Id { get; set; }
        public int Total { get; set; }
        public float Differential { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public Guid? GolfCourseId { get; set; }
        public User User { get; set; }
        public GolfCourse? GolfCourse { get; set; }
    }
}
