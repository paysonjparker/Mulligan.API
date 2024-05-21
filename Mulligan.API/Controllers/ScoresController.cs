using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mulligan.API.BusinessServices;
using Mulligan.API.Models.Requests.ScoreRequests;

namespace Mulligan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAngularOrigins")]
    public class ScoresController : ControllerBase
    {
        private IScoreBusinessService _scoreBusinessService;

        public ScoresController(IScoreBusinessService scoreBusinessService)
        {
            _scoreBusinessService = scoreBusinessService;
        }

        [HttpPost]
        public IActionResult AddScore(AddScoreRequest addScoreRequest)
        {
            try
            {
                var score = _scoreBusinessService.AddScore(addScoreRequest);

                return Created("", score);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{userId:int}")]
        public IActionResult GetAllScoresByUser(int userId)
        {
            try
            {
                var scores = _scoreBusinessService.GetAllScoresByUser(userId);

                if (scores == null)
                {
                    return NotFound();
                }
                return Ok(scores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{golfCourseId:int}")]
        public IActionResult GetAllScoresByGolfCourseId(int golfCourseId)
        {
            try
            {
                var scores = _scoreBusinessService.GetAllScoresByGolfCourse(golfCourseId);

                if (scores == null)
                {
                    return NotFound();
                }
                return Ok(scores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteScore(int id)
        {
            try
            {
                var deletedScore = _scoreBusinessService.DeleteScore(id);

                if (deletedScore != false)
                {
                    return NoContent();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
