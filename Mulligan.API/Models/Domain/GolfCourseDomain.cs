using System.ComponentModel.DataAnnotations;

namespace Mulligan.API.Models.Domain
{
    public class GolfCourseDomain
    {
        [Key]
        public Guid GOLF_COURSE_ID { get; set; }
        public string NAME { get; set; }
        public string CITY { get; set; }
        public string? SUBDIVISION { get; set; }
        public string COUNTRY { get; set; }
        public int YARDAGE { get; set; }
        public int PAR { get; set; }
        public int SLOPE_RATING { get; set; }
        public float COURSE_RATING { get; set; }
        public ICollection<ScoreDomain>? SCORES { get; set; }
        public ICollection<UserDomain>? USERS { get; set; }
    }
}
