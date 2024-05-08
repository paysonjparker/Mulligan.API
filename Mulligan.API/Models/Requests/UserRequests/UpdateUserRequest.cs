using System.Diagnostics.CodeAnalysis;

namespace Mulligan.API.Models.Requests.UserRequests
{
    [ExcludeFromCodeCoverage]
    public class UpdateUserRequest
    {
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? EmailAddress { get; set; }
        public Guid? GolfCourseId { get; set; }
    }
}
