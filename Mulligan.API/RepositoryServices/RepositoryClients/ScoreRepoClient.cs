using Mulligan.API.BusinessServices;
using Mulligan.API.Data;
using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.ScoreRequests;
using Mulligan.API.Models.Requests.UserRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public class ScoreRepoClient : IScoreRepoClient
    {
        private readonly MulliganDbContext _dbContext;

        public ScoreRepoClient(MulliganDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Score AddScore(AddScoreRequest addScoreRequest)
        {
            var user = _dbContext.User.Find(addScoreRequest.UserId);

            var score = new Score
            {
                Total = addScoreRequest.Total,
                Differential = CalculateScoreDifferential(addScoreRequest.Total, addScoreRequest.GolfCourseId),
                CreatedDate = DateTime.Now,
                UserId = addScoreRequest.UserId,
                GolfCourseId = addScoreRequest.GolfCourseId,
            };

            if(user != null)
            {
                user.HandicapIndex = (float)Math.Round(CalculateHandicapIndex(user.Id), 1);
            }

            _dbContext.Score.Add(score);
            _dbContext.SaveChanges();

            return score;
        }

        public List<Score> GetAllScores()
        {
            var scores = _dbContext.Score.ToList();

            return scores;
        }

        public List<Score> GetAllScoresByUser(int userId)
        {
            var scores = _dbContext.Score.ToList().Where(user => user.UserId.Equals(userId)).ToList();

            return scores;
        }

        public List<Score> GetAllScoresByGolfCourse(int golfCourseId)
        {
            var scores = _dbContext.Score.Where(score => score.GolfCourseId.Equals(golfCourseId)).ToList();

            return scores;
        }

        public bool DeleteScore(int id)
        {
            var score = _dbContext.Score.Find(id);

            if (score != null)
            {
                _dbContext.Score.Remove(score);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public float CalculateHandicapIndex(int userId)
        {
            var scoreList = GetAllScoresByUser(userId);

            scoreList.Reverse();

            if (scoreList.Count > 20)
            {
                scoreList = scoreList.Take(20).ToList();
            }
            scoreList = scoreList.OrderBy(score => score.Differential).ToList();
            if (scoreList.Count == 1)
            {
                return scoreList.ElementAt(0).Differential - 2;
            }
            if (scoreList.Count == 2 || scoreList.Count == 3)
            {
                return scoreList.ElementAt(0).Differential - 2;
            }
            if (scoreList.Count == 4)
            {
                return scoreList.ElementAt(0).Differential - 1;
            }
            if (scoreList.Count == 5)
            {
                return scoreList.ElementAt(0).Differential;
            }
            if (scoreList.Count == 6)
            {
                return ((scoreList.ElementAt(0).Differential + scoreList.ElementAt(1).Differential) / 2) - 1;
            }
            if (scoreList.Count == 7 || scoreList.Count == 8)
            {
                return (scoreList.ElementAt(0).Differential + scoreList.ElementAt(1).Differential) / 2;
            }
            if (scoreList.Count >= 9 && scoreList.Count <= 11)
            {
                return (scoreList.ElementAt(0).Differential + scoreList.ElementAt(1).Differential + scoreList.ElementAt(2).Differential) / 3;
            }
            if (scoreList.Count >= 12 && scoreList.Count <= 14)
            {
                return (scoreList.ElementAt(0).Differential + scoreList.ElementAt(1).Differential
                    + scoreList.ElementAt(2).Differential + scoreList.ElementAt(3).Differential) / 4;
            }
            if (scoreList.Count == 15 || scoreList.Count == 16)
            {
                return (scoreList.ElementAt(0).Differential + scoreList.ElementAt(1).Differential
                    + scoreList.ElementAt(2).Differential + scoreList.ElementAt(3).Differential
                    + scoreList.ElementAt(4).Differential) / 5;
            }
            if (scoreList.Count == 17 || scoreList.Count == 18)
            {
                return (scoreList.ElementAt(0).Differential + scoreList.ElementAt(1).Differential
                    + scoreList.ElementAt(2).Differential + scoreList.ElementAt(3).Differential
                    + scoreList.ElementAt(4).Differential + scoreList.ElementAt(5).Differential) / 6;
            }
            if (scoreList.Count == 19)
            {
                return (scoreList.ElementAt(0).Differential + scoreList.ElementAt(1).Differential
                    + scoreList.ElementAt(2).Differential + scoreList.ElementAt(3).Differential
                    + scoreList.ElementAt(4).Differential + scoreList.ElementAt(5).Differential
                    + scoreList.ElementAt(6).Differential) / 7;
            }
            if (scoreList.Count >= 20)
            {
                return (scoreList.ElementAt(0).Differential + scoreList.ElementAt(1).Differential
                    + scoreList.ElementAt(2).Differential + scoreList.ElementAt(3).Differential
                    + scoreList.ElementAt(4).Differential + scoreList.ElementAt(5).Differential
                    + scoreList.ElementAt(6).Differential + scoreList.ElementAt(7).Differential) / 8;
            }

            return 0;
        }

        public float CalculateScoreDifferential(int scoreTotal, int golfCourseId)
        {
            var golfCourse = _dbContext.GolfCourse.Find(golfCourseId);

            if(golfCourse != null)
            {
                float slopeRating = golfCourse.SlopeRating;
                float courseRating = golfCourse.CourseRating;

                var differential = ((113 / slopeRating) * (scoreTotal - courseRating));

                return (float)Math.Round(differential, 1);
            }

            return 0;
        }
    }
}
