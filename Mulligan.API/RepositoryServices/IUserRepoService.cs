using Mulligan.API.Models.Authentication;
using Mulligan.API.Models.Requests.UserRequests;
using Mulligan.API.Models.Responses;

namespace Mulligan.API.RepositoryServices
{
    public interface IUserRepoService
    {
        public UserResponse AddUser(AddUserRequest addUserRequest);
        public IEnumerable<UserResponse> GetAllUsers();
        public IEnumerable<UserResponse> GetAllUsersByGolfCourse(int golfCourseId);
        public UserResponse GetUserById(int userId);
        public UserResponse UpdateUser(int userId, UpdateUserRequest updateUserRequest);
        public bool DeleteUser(int userId);
        public AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest);
    }
}
