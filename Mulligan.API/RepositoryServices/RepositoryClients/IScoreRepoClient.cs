using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.ScoreRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public interface IScoreRepoClient
    {
        public Score AddScore(AddScoreRequest addScoreRequest);
        public List<Score> GetAllScoresByUser(Guid userId);
        public List<Score> GetAllScoresByGolfCourse(Guid golfCourseId);
        public bool DeleteScore(Guid id);
        public float CalculateHandicapIndex(Guid userId);
        public float CalculateScoreDifferential(int scoreTotal, Guid golfCourseId);
    }
}
