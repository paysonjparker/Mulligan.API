using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.ScoreRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public interface IScoreRepoClient
    {
        public ScoreDomain AddScore(AddScoreRequest addScoreRequest);
        public List<ScoreDomain> GetAllScoresByUser(Guid userId);
        public List<ScoreDomain> GetAllScoresByGolfCourse(Guid golfCourseId);
        public bool DeleteScore(Guid id);
        public float CalculateHandicapIndex(Guid userId);
        public float CalculateScoreDifferential(int scoreTotal, Guid golfCourseId);
    }
}
