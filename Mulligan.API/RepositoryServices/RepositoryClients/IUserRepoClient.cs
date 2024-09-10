using Mulligan.API.Models.Authentication;
using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.UserRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public interface IUserRepoClient
    {
        public User AddUser(AddUserRequest addUserRequest);
        public List<User> GetAllUsers();
        public List<User> GetAllUsersByGolfCourse(int golfCourseId);
        public User GetUserById(int id);
        public User UpdateUser(int id, UpdateUserRequest updateUserRequest);
        public bool DeleteUser(int id);
        public List<User> SearchUsers(SearchUserRequest searchUserRequest);
        public AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest);
    }
}
