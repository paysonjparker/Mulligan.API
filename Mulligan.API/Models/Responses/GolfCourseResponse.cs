using Mulligan.API.Models.Domain;

namespace Mulligan.API.Models.Responses
{
    public class GolfCourseResponse
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public int SlopeRating { get; set; }
        public float CourseRating { get; set; }
        public int Yardage { get; set; }
        public int Par { get; set; }
        public ICollection<ScoreDomain> Scores { get; set; }
        public ICollection<UserDomain> Users { get; set; }
    }
}
