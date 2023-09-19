namespace Mulligan.API.Models.DataTransferObjects.ScoreDto
{
    public class AddScoreRequest
    {
        public int Total { get; set; }
        public float Differential { get; set; }
        public Guid UserId { get; set; }
    }
}
