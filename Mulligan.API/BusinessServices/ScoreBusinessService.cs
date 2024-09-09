
using Mulligan.API.Models.Requests.ScoreRequests;
using Mulligan.API.Models.Responses;
using Mulligan.API.RepositoryServices;

namespace Mulligan.API.BusinessServices
{
    public class ScoreBusinessService : IScoreBusinessService
    {
        private readonly IScoreRepoService _scoreRepoService;

        public ScoreBusinessService(IScoreRepoService scoreRepoService)
        {
            _scoreRepoService = scoreRepoService;
        }

        public ScoreResponse AddScore(AddScoreRequest addScoreRequest)
        {
            return _scoreRepoService.AddScore(addScoreRequest);
        }

        public IEnumerable<ScoreResponse> GetAllScores()
        {
            return _scoreRepoService.GetAllScores();
        }

        public IEnumerable<ScoreResponse> GetAllScoresByUser(int userId)
        {
            return _scoreRepoService.GetAllScoresByUser(userId);
        }

        public IEnumerable<ScoreResponse> GetAllScoresByGolfCourse(int golfCourseId)
        {
            return _scoreRepoService.GetAllScoresByGolfCourse(golfCourseId);
        }

        public bool DeleteScore(int postId)
        {
            return _scoreRepoService.DeleteScore(postId);
        }
    }
}
