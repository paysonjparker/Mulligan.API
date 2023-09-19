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

        public Score AddScore(AddScoreRequest addScoreRequest)
        {
            // Convert DTO to Domain Model
            var score = new Score
            {
                Total = addScoreRequest.Total,
                Differential = addScoreRequest.Differential,
                GolfCourseId = addScoreRequest.UserId
            };

            _dbContext.Scores.Add(score);
            _dbContext.SaveChanges();

            return score;
        }

        public List<Score> GetAllScoresByUser(Guid userId)
        {

            var scores = _dbContext.Scores.ToList();

            var scoresDTO = new List<Score>();
            foreach (var score in scores)
            {
                if (score.UserId == userId)
                {
                    scoresDTO.Add(new Score
                    {
                        Id = score.Id,
                        Total = score.Total,
                        Differential = score.Differential,
                        UserId = score.UserId,
                    });
                }
            }

            return scoresDTO;
        }

        public bool DeleteScore(Guid id)
        {
            var existingScore = _dbContext.Scores.Find(id);

            if (existingScore != null)
            {
                _dbContext.Scores.Remove(existingScore);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
