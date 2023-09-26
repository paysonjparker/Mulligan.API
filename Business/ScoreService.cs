using Mulligan.API.Data;
using Mulligan.API.Models.DataTransferObjects.ScoreDto;
using Mulligan.API.Models.DomainModels;

namespace Mulligan.API.Business
{
    public class ScoreService
    {
        private readonly MulliganDbContext _dbContext;

        public ScoreService(MulliganDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Score> GetAllScoresByUser(Guid userId)
        {

            var scores = _dbContext.Scores.ToList();

            var scoresDto = new List<Score>();
            foreach (var score in scores)
            {
                if (score.UserId == userId)
                {
                    scoresDto.Add(new Score
                    {
                        Id = score.Id,
                        Total = score.Total,
                        Differential = score.Differential,
                        UserId = score.UserId,
                        GolfCourseId = score.GolfCourseId,
                    });
                }
            }

            return scoresDto;
        }

        public float CalculateHandicapIndex(Guid userId)
        {
            var scoreList = GetAllScoresByUser(userId);

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

        public float CalculateScoreDifferential(int scoreTotal, Guid golfCourseId)
        {
            var golfCourseService = new GolfCourseService(_dbContext);

            var golfCourse = golfCourseService.GetGolfCourseById(golfCourseId);

            var differential = ((113 / golfCourse.SlopeRating) * (scoreTotal - golfCourse.CourseRating));
            
            return differential;
        }
    }
}
