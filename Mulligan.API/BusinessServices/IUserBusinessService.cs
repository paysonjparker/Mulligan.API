using Mulligan.API.Models.Authentication;
using Mulligan.API.Models.Requests.UserRequests;
using Mulligan.API.Models.Responses;

namespace Mulligan.API.BusinessServices
{
    public interface IUserBusinessService
    {
        public UserResponse AddUser(AddUserRequest addUserRequest);
        public UserResponse GetUserById(int userId);
        public IEnumerable<UserResponse> GetAllUsers();
        public IEnumerable<UserResponse> GetAllUsersByGolfCourse(int golfCourseId);
        public UserResponse UpdateUser(int userId, UpdateUserRequest updateUserRequest);
        public bool DeleteScore(int userId);
        public AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest);
    }
}
