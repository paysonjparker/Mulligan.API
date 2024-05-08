using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.UserRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public interface IUserRepoClient
    {
        public User AddUser(AddUserRequest addUserRequest);
        public List<User> GetAllUsers();
        public List<User> GetAllUsersByGolfCourse(Guid golfCourseId);
        public User GetUserById(Guid id);
        public User UpdateUser(Guid id, UpdateUserRequest updateUserRequest);
        public bool DeleteUser(Guid id);
    }
}
