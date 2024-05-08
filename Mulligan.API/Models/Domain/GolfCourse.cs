using System.ComponentModel.DataAnnotations;

namespace Mulligan.API.Models.Domain
{
    public class GolfCourse
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string? Subdivision { get; set; }
        public string Country { get; set; }
        public int Yardage { get; set; }
        public int Par { get; set; }
        public int SlopeRating { get; set; }
        public float CourseRating { get; set; }
        public ICollection<Score>? Scores { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
