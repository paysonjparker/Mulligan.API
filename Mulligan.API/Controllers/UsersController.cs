using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mulligan.API.Authorization;
using Mulligan.API.BusinessServices;
using Mulligan.API.Models.Authentication;
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

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest authenticateRequest)
        {
            var response = _userBusinessService.Authenticate(authenticateRequest);
            return Ok(response);
        }

        [Authorize]
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

        [Authorize]
        [HttpGet]
        [Route("golfCourse/{golfCourseId:int}")]
        public IActionResult GetAllUsersByGolfCourse(int golfCourseId)
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

        [Authorize]
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetUserById(int id)
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

        [Authorize]
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

        [Authorize]
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateUser(int id, UpdateUserRequest updateUserRequest)
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

        [Authorize]
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteUser(int id)
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
