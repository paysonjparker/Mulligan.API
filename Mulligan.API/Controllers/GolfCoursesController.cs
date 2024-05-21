using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mulligan.API.BusinessServices;
using Mulligan.API.Models.Requests.GolfCourseRequests;

namespace Mulligan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAngularOrigins")]
    public class GolfCoursesController : ControllerBase
    {
        private IGolfCourseBusinessService _golfCourseBusinessService;

        public GolfCoursesController(IGolfCourseBusinessService golfCourseBusinessService)
        {
            _golfCourseBusinessService = golfCourseBusinessService;
        }

        [HttpPost]
        public IActionResult AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest)
        {
            try
            {
                var createdGolfCourse = _golfCourseBusinessService.AddGolfCourse(addGolfCourseRequest);

                return Created("", createdGolfCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllGolfCourses()
        {
            try
            {
                var golfCourses = _golfCourseBusinessService.GetAllGolfCourses();

                if (golfCourses == null)
                {
                    return NotFound();
                }
                return Ok(golfCourses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetGolfCourseById(int id)
        {
            try
            {
                var golfCourse = _golfCourseBusinessService.GetGolfCourseById(id);

                if (golfCourse == null)
                {
                    return NotFound();
                }
                return Ok(golfCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("names")]
        public IActionResult GetAllGolfCourseNames()
        {
            try
            {
                var golfCourses = _golfCourseBusinessService.GetAllGolfCourses();
                if(golfCourses == null)
                {
                    return NotFound();
                }
                var golfCourseNames = new List<string>();

                foreach (var golfCourse in golfCourses)
                {
                    golfCourseNames.Add(golfCourse.Name);
                }

                return Ok(golfCourseNames);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteGolfCourse(int id)
        {
            try
            {
                var deletedGolfCourse = _golfCourseBusinessService.DeleteGolfCourse(id);

                if (deletedGolfCourse != false)
                {
                    return NoContent();
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateGolfCourse(int id, UpdateGolfCourseRequest updateGolfCourseRequest)
        {
            try
            {
                var existingGolfCourse = _golfCourseBusinessService.UpdateGolfCourse(id, updateGolfCourseRequest);

                return Ok(existingGolfCourse);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }    
        }
    }
}
