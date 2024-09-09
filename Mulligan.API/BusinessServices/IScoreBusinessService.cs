using Mulligan.API.Models.Requests.ScoreRequests;
using Mulligan.API.Models.Responses;

namespace Mulligan.API.BusinessServices
{
    public interface IScoreBusinessService
    {
        public ScoreResponse AddScore(AddScoreRequest addScoreRequest);
        public IEnumerable<ScoreResponse> GetAllScores();
        public IEnumerable<ScoreResponse> GetAllScoresByUser(int userId);
        public IEnumerable<ScoreResponse> GetAllScoresByGolfCourse(int golfCourseId);
        public bool DeleteScore(int postId);
    }
}
