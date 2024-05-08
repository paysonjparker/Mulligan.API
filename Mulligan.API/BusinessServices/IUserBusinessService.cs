using Mulligan.API.Models.Requests.UserRequests;
using Mulligan.API.Models.Responses;

namespace Mulligan.API.BusinessServices
{
    public interface IUserBusinessService
    {
        public UserResponse AddUser(AddUserRequest addUserRequest);
        public UserResponse GetUserById(Guid userId);
        public IEnumerable<UserResponse> GetAllUsers();
        public IEnumerable<UserResponse> GetAllUsersByGolfCourse(Guid golfCourseId);
        public UserResponse UpdateUser(Guid userId, UpdateUserRequest updateUserRequest);
        public bool DeleteScore(Guid userId);
    }
}
