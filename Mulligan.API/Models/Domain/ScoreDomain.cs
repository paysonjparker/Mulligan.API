using System.ComponentModel.DataAnnotations;

namespace Mulligan.API.Models.Domain
{
    public class ScoreDomain
    {
        [Key]
        public Guid SCORE_ID { get; set; }
        public int TOTAL { get; set; }
        public float DIFFERENTIAL { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public Guid USER_ID { get; set; }
        public Guid? GOLF_COURSE_ID { get; set; }
    }
}
