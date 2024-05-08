
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

        public IEnumerable<ScoreResponse> GetAllScoresByUser(Guid userId)
        {
            return _scoreRepoService.GetAllScoresByUser(userId);
        }

        public IEnumerable<ScoreResponse> GetAllScoresByGolfCourse(Guid golfCourseId)
        {
            return _scoreRepoService.GetAllScoresByGolfCourse(golfCourseId);
        }

        public bool DeleteScore(Guid postId)
        {
            return _scoreRepoService.DeleteScore(postId);
        }
    }
}
