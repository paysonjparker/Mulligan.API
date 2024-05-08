using Mulligan.API.Models.Requests.ScoreRequests;
using Mulligan.API.Models.Responses;

namespace Mulligan.API.BusinessServices
{
    public interface IScoreBusinessService
    {
        public ScoreResponse AddScore(AddScoreRequest addScoreRequest);
        public IEnumerable<ScoreResponse> GetAllScoresByUser(Guid userId);
        public IEnumerable<ScoreResponse> GetAllScoresByGolfCourse(Guid golfCourseId);
        public bool DeleteScore(Guid postId);
    }
}
