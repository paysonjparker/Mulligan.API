using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mulligan.API.BusinessServices;
using Mulligan.API.Models.Requests.UserRequests;

namespace Mulligan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAngularOrigins")]
    public class UsersController : ControllerBase
    {
        private IUserBusinessService _userBusinessService;

        public UsersController(IUserBusinessService userBusinessService)
        {
            _userBusinessService = userBusinessService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userBusinessService.GetAllUsers();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("golfCourse/{golfCourseId:Guid}")]
        public IActionResult GetAllUsersByGolfCourse(Guid golfCourseId)
        {
            try
            {
                var users = _userBusinessService.GetAllUsersByGolfCourse(golfCourseId);

                return Ok(users);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetUserById(Guid id)
        {
            try
            {
                var user = _userBusinessService.GetUserById(id);

                if (user != null)
                {
                    return Ok(user);
                }

                return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddUser(AddUserRequest addUserRequest)
        {
            try
            {
                var user = _userBusinessService.AddUser(addUserRequest);

                return Created("", user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateUser(Guid id, UpdateUserRequest updateUserRequest)
        {
            try
            {
                var existingUser = _userBusinessService.UpdateUser(id, updateUserRequest);

                if (existingUser != null)
                {
                    return Ok(existingUser);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                var existingUser = _userBusinessService.DeleteScore(id);

                if (existingUser != false)
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
    }
}
