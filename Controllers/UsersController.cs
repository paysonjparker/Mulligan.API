using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mulligan.API.Business;
using Mulligan.API.Data;
using Mulligan.API.Models.DataTransferObjects.UserDto;

namespace Mulligan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAngularOrigins")]
    public class UsersController : ControllerBase
    {
        private UserService _userService;

        public UsersController(MulliganDbContext dbContext)
        {
            this._userService = new UserService(dbContext);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();

            users = users.OrderBy(x => x.Name).ToList();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = _userService.GetUserById(id);

            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddUser(AddUserRequest addUserRequest)
        {
            var user = _userService.AddUser(addUserRequest);

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateUser(Guid id, UpdateUserRequest updateUserRequest)
        {
            var existingUser = _userService.UpdateUser(id, updateUserRequest);

            if (existingUser != null)
            {
                return Ok(existingUser);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            var existingUser = _userService.DeleteUser(id);

            if (existingUser != false)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
