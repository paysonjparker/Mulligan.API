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

        [HttpPost]
        public IActionResult AddUser(AddUserRequest addUserRequest)
        {
            var user = _userService.AddUser(addUserRequest);

            return Ok(user);
        }
    }
}
