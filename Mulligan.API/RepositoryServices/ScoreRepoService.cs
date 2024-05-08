using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.ScoreRequests;
using Mulligan.API.Models.Responses;
using Mulligan.API.RepositoryServices.RepositoryClients;

namespace Mulligan.API.RepositoryServices
{
    public class ScoreRepoService : IScoreRepoService
    {
        private readonly IScoreRepoClient _scoreRepoClient;

        public ScoreRepoService(IScoreRepoClient scoreRepoClient)
        {
            _scoreRepoClient = scoreRepoClient;
        }

        public ScoreResponse AddScore(AddScoreRequest addScoreRequest)
        {
            return ConvertScore(_scoreRepoClient.AddScore(addScoreRequest));
        }

        public IEnumerable<ScoreResponse> GetAllScoresByUser(Guid userId)
        {
            return ConvertScores(_scoreRepoClient.GetAllScoresByUser(userId));
        }

        public IEnumerable<ScoreResponse> GetAllScoresByGolfCourse(Guid golfCourseId)
        {
            return ConvertScores(_scoreRepoClient.GetAllScoresByGolfCourse(golfCourseId));
        }

        public bool DeleteScore(Guid scoreId)
        {
            return _scoreRepoClient.DeleteScore(scoreId);
        }

        private ScoreResponse ConvertScore(ScoreDomain scoreDomain)
        {
            if (scoreDomain == null)
            {
                return null;
            }
            ScoreResponse scoreResponse = new ScoreResponse
            {
                ScoreId = scoreDomain.SCORE_ID,
                Differential = scoreDomain.DIFFERENTIAL,
                Total = scoreDomain.TOTAL,
                CreatedDate = scoreDomain.CREATED_DATE,
                UserId = scoreDomain.USER_ID,
                GolfCourseId = scoreDomain.GOLF_COURSE_ID,
            };

            return scoreResponse;
        }

        private List<ScoreResponse> ConvertScores(IEnumerable<ScoreDomain> scoreDomains)
        {
            if (scoreDomains == null)
            {
                return null;
            }
            var scoreResponses = new List<ScoreResponse>();
            foreach (var scoreDomain in scoreDomains)
            {
                var scoreResponse = ConvertScore(scoreDomain);
                if (scoreResponse != null)
                {
                    scoreResponses.Add(scoreResponse);
                }
            }
            return scoreResponses;
        }
    }
}
