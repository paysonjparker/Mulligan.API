using Mulligan.API.Models.Requests.UserRequests;
using Mulligan.API.Models.Responses;

namespace Mulligan.API.RepositoryServices
{
    public interface IUserRepoService
    {
        public UserResponse AddUser(AddUserRequest addUserRequest);
        public IEnumerable<UserResponse> GetAllUsers();
        public IEnumerable<UserResponse> GetAllUsersByGolfCourse(Guid golfCourseId);
        public UserResponse GetUserById(Guid userId);
        public UserResponse UpdateUser(Guid userId, UpdateUserRequest updateUserRequest);
        public bool DeleteUser(Guid userId);
    }
}
