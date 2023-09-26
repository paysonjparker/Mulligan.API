using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mulligan.API.Business;
using Mulligan.API.Data;
using Mulligan.API.Models.DataTransferObjects.ScoreDto;

namespace Mulligan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAngularOrigins")]
    public class ScoresController : ControllerBase
    {
        private ScoreService _scoreService;

        public ScoresController(MulliganDbContext dbContext)
        {
            this._scoreService = new ScoreService(dbContext);
        }

        [HttpPost]
        public IActionResult AddScore(AddScoreRequest addScoreRequest)
        {
            var score = _scoreService.AddScore(addScoreRequest);

            return Ok(score);
        }

        [HttpGet]
        [Route("{userId:Guid}")]
        public IActionResult GetAllScoresByUser(Guid userId)
        {
            var scores = _scoreService.GetAllScoresByUser(userId);

            return Ok(scores);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteScore(Guid id)
        {
            var existingScore = _scoreService.DeleteScore(id);

            if (existingScore != false)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
