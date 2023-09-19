namespace Mulligan.API.Models.DataTransferObjects.UserDto
{
    public class UpdateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
