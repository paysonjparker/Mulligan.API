
namespace Mulligan.API.Models.Requests.UserRequests
{
    public class SearchUserRequest
    {
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? EmailAddress { get; set; }
        public string? HomeCourseName { get; set; }
    }
}
