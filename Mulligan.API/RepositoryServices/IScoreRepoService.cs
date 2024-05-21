using Mulligan.API.Models.Requests.ScoreRequests;
using Mulligan.API.Models.Responses;

namespace Mulligan.API.RepositoryServices
{
    public interface IScoreRepoService
    {
        public ScoreResponse AddScore(AddScoreRequest addScoreRequest);
        public IEnumerable<ScoreResponse> GetAllScoresByUser(int userId);
        public IEnumerable<ScoreResponse> GetAllScoresByGolfCourse(int golfCourseId);
        public bool DeleteScore(int scoreId);
    }
}
