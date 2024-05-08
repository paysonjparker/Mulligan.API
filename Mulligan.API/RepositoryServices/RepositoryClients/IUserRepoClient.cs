using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.UserRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public interface IUserRepoClient
    {
        public UserDomain AddUser(AddUserRequest addUserRequest);
        public List<UserDomain> GetAllUsers();
        public List<UserDomain> GetAllUsersByGolfCourse(Guid golfCourseId);
        public UserDomain GetUserById(Guid id);
        public UserDomain UpdateUser(Guid id, UpdateUserRequest updateUserRequest);
        public bool DeleteUser(Guid id);
    }
}
