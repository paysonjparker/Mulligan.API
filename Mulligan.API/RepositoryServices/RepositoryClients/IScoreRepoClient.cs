using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.ScoreRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public interface IScoreRepoClient
    {
        public Score AddScore(AddScoreRequest addScoreRequest);
        public List<Score> GetAllScores();
        public List<Score> GetAllScoresByUser(int userId);
        public List<Score> GetAllScoresByGolfCourse(int golfCourseId);
        public bool DeleteScore(int id);
        public float CalculateHandicapIndex(int userId);
        public float CalculateScoreDifferential(int scoreTotal, int golfCourseId);
    }
}
