using System.Reflection.Metadata.Ecma335;

namespace Mulligan.API.Models.DomainModels
{
    public class Score
    {
        public Guid Id { get; set; }
        public int Total { get; set; }
        public float Differential { get; set; }
        public Guid GolfCourseId { get; set; }
        public Guid UserId { get; set; }
    }
}
