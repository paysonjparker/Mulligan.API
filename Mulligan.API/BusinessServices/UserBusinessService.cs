using Mulligan.API.Models.Authentication;
using Mulligan.API.Models.Requests.UserRequests;
using Mulligan.API.Models.Responses;
using Mulligan.API.RepositoryServices;

namespace Mulligan.API.BusinessServices
{
    public class UserBusinessService : IUserBusinessService
    {
        private readonly IUserRepoService _userRepoService;

        public UserBusinessService(IUserRepoService userRepoService)
        {
            _userRepoService = userRepoService;
        }

        public UserResponse AddUser(AddUserRequest addUserRequest)
        {
            return _userRepoService.AddUser(addUserRequest);
        }

        public UserResponse GetUserById(int userId)
        {
            return _userRepoService.GetUserById(userId);
        }

        public IEnumerable<UserResponse> GetAllUsers()
        {
            return _userRepoService.GetAllUsers();
        }

        public IEnumerable<UserResponse> GetAllUsersByGolfCourse(int golfCourseId)
        {
            return _userRepoService.GetAllUsersByGolfCourse(golfCourseId);
        }
        public UserResponse UpdateUser(int userId, UpdateUserRequest updateUserRequest)
        {
            return _userRepoService.UpdateUser(userId, updateUserRequest);
        }

        public bool DeleteScore(int userId)
        {
            return _userRepoService.DeleteUser(userId);
        }

        public IEnumerable<UserResponse> SearchUsers(string? searchUserRequest)
        {
            return _userRepoService.SearchUsers(searchUserRequest);
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest)
        {
            return _userRepoService.Authenticate(authenticateRequest);
        }
    }
}
