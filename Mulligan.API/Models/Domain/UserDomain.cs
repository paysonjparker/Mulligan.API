using System.ComponentModel.DataAnnotations;

namespace Mulligan.API.Models.Domain
{
    public class UserDomain
    {
        [Key]
        public Guid USER_ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string FULL_NAME { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public float HANDICAP_INDEX { get; set; }
        public string? HOME_COURSE_NAME { get; set; }
        public ICollection<ScoreDomain>? SCORES { get; set; }
        public ICollection<PostDomain>? POSTS { get; set; }
        public Guid? GOLF_COURSE_ID { get; set; }
    }
}
