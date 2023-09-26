namespace Mulligan.API.Models.DataTransferObjects.UserDto
{
    public class UpdateUserRequest
    {
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public float HandicapIndex { get; set; }
        public Guid GolfCourseId { get; set; }
    }
}
