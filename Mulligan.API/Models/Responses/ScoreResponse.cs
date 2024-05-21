namespace Mulligan.API.Models.Responses
{
    public class ScoreResponse
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public float Differential { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public int? GolfCourseId { get; set; }
    }
}
