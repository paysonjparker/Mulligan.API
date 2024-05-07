namespace Mulligan.API.Models.Requests.ScoreRequests
{
    public class AddScoreRequest
    {
        public int Total { get; set; }
        public Guid UserId { get; set; }
        public Guid GolfCourseId { get; set; }
    }
}
