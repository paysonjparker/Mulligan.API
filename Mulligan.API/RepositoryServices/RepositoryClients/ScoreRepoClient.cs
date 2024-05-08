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

        public ScoreDomain AddScore(AddScoreRequest addScoreRequest)
        {
            var user = _dbContext.USER.Find(addScoreRequest.UserId);

            var score = new ScoreDomain
            {
                TOTAL = addScoreRequest.Total,
                DIFFERENTIAL = CalculateScoreDifferential(addScoreRequest.Total, addScoreRequest.GolfCourseId),
                CREATED_DATE = DateTime.Now,
                USER_ID = addScoreRequest.UserId,
                GOLF_COURSE_ID = addScoreRequest.GolfCourseId,
            };

            if(user != null)
            {
                user.HANDICAP_INDEX = (float)Math.Round(CalculateHandicapIndex(user.USER_ID), 1);
            }

            _dbContext.SCORE.Add(score);
            _dbContext.SaveChanges();

            return score;
        }

        public List<ScoreDomain> GetAllScoresByUser(Guid userId)
        {
            var scores = _dbContext.SCORE.ToList().Where(user => user.USER_ID.Equals(userId)).ToList();

            return scores;
        }

        public List<ScoreDomain> GetAllScoresByGolfCourse(Guid golfCourseId)
        {
            var scores = _dbContext.SCORE.Where(score => score.GOLF_COURSE_ID.Equals(golfCourseId)).ToList();

            return scores;
        }

        public bool DeleteScore(Guid id)
        {
            var score = _dbContext.SCORE.Find(id);

            if (score != null)
            {
                _dbContext.SCORE.Remove(score);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public float CalculateHandicapIndex(Guid userId)
        {
            var scoreList = GetAllScoresByUser(userId);

            scoreList.Reverse();

            if (scoreList.Count > 20)
            {
                scoreList = scoreList.Take(20).ToList();
            }
            scoreList = scoreList.OrderBy(score => score.DIFFERENTIAL).ToList();
            if (scoreList.Count == 1)
            {
                return scoreList.ElementAt(0).DIFFERENTIAL - 2;
            }
            if (scoreList.Count == 2 || scoreList.Count == 3)
            {
                return scoreList.ElementAt(0).DIFFERENTIAL - 2;
            }
            if (scoreList.Count == 4)
            {
                return scoreList.ElementAt(0).DIFFERENTIAL - 1;
            }
            if (scoreList.Count == 5)
            {
                return scoreList.ElementAt(0).DIFFERENTIAL;
            }
            if (scoreList.Count == 6)
            {
                return ((scoreList.ElementAt(0).DIFFERENTIAL + scoreList.ElementAt(1).DIFFERENTIAL) / 2) - 1;
            }
            if (scoreList.Count == 7 || scoreList.Count == 8)
            {
                return (scoreList.ElementAt(0).DIFFERENTIAL + scoreList.ElementAt(1).DIFFERENTIAL) / 2;
            }
            if (scoreList.Count >= 9 && scoreList.Count <= 11)
            {
                return (scoreList.ElementAt(0).DIFFERENTIAL + scoreList.ElementAt(1).DIFFERENTIAL + scoreList.ElementAt(2).DIFFERENTIAL) / 3;
            }
            if (scoreList.Count >= 12 && scoreList.Count <= 14)
            {
                return (scoreList.ElementAt(0).DIFFERENTIAL + scoreList.ElementAt(1).DIFFERENTIAL
                    + scoreList.ElementAt(2).DIFFERENTIAL + scoreList.ElementAt(3).DIFFERENTIAL) / 4;
            }
            if (scoreList.Count == 15 || scoreList.Count == 16)
            {
                return (scoreList.ElementAt(0).DIFFERENTIAL + scoreList.ElementAt(1).DIFFERENTIAL
                    + scoreList.ElementAt(2).DIFFERENTIAL + scoreList.ElementAt(3).DIFFERENTIAL
                    + scoreList.ElementAt(4).DIFFERENTIAL) / 5;
            }
            if (scoreList.Count == 17 || scoreList.Count == 18)
            {
                return (scoreList.ElementAt(0).DIFFERENTIAL + scoreList.ElementAt(1).DIFFERENTIAL
                    + scoreList.ElementAt(2).DIFFERENTIAL + scoreList.ElementAt(3).DIFFERENTIAL
                    + scoreList.ElementAt(4).DIFFERENTIAL + scoreList.ElementAt(5).DIFFERENTIAL) / 6;
            }
            if (scoreList.Count == 19)
            {
                return (scoreList.ElementAt(0).DIFFERENTIAL + scoreList.ElementAt(1).DIFFERENTIAL
                    + scoreList.ElementAt(2).DIFFERENTIAL + scoreList.ElementAt(3).DIFFERENTIAL
                    + scoreList.ElementAt(4).DIFFERENTIAL + scoreList.ElementAt(5).DIFFERENTIAL
                    + scoreList.ElementAt(6).DIFFERENTIAL) / 7;
            }
            if (scoreList.Count >= 20)
            {
                return (scoreList.ElementAt(0).DIFFERENTIAL + scoreList.ElementAt(1).DIFFERENTIAL
                    + scoreList.ElementAt(2).DIFFERENTIAL + scoreList.ElementAt(3).DIFFERENTIAL
                    + scoreList.ElementAt(4).DIFFERENTIAL + scoreList.ElementAt(5).DIFFERENTIAL
                    + scoreList.ElementAt(6).DIFFERENTIAL + scoreList.ElementAt(7).DIFFERENTIAL) / 8;
            }

            return 0;
        }

        public float CalculateScoreDifferential(int scoreTotal, Guid golfCourseId)
        {
            var golfCourse = _dbContext.GOLF_COURSE.Find(golfCourseId);

            if(golfCourse != null)
            {
                float slopeRating = golfCourse.SLOPE_RATING;
                float courseRating = golfCourse.COURSE_RATING;

                var differential = ((113 / slopeRating) * (scoreTotal - courseRating));

                return (float)Math.Round(differential, 1);
            }

            return 0;
        }
    }
}
