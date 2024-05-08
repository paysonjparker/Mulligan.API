using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.ScoreRequests;
using Mulligan.API.Models.Requests.UserRequests;
using Mulligan.API.Models.Responses;
using Mulligan.API.RepositoryServices.RepositoryClients;

namespace Mulligan.API.RepositoryServices
{
    public class UserRepoService : IUserRepoService
    {
        private readonly IUserRepoClient _userRepoClient;

        public UserRepoService(IUserRepoClient userRepoClient)
        {
            _userRepoClient = userRepoClient;
        }

        public UserResponse AddUser(AddUserRequest addUserRequest)
        {
            return ConvertUser(_userRepoClient.AddUser(addUserRequest));
        }

        public IEnumerable<UserResponse> GetAllUsers()
        {
            return ConvertUsers(_userRepoClient.GetAllUsers());
        }

        public IEnumerable<UserResponse> GetAllUsersByGolfCourse(Guid golfCourseId)
        {
            return ConvertUsers(_userRepoClient.GetAllUsersByGolfCourse(golfCourseId));
        }

        public UserResponse GetUserById(Guid userId)
        {
            return ConvertUser(_userRepoClient.GetUserById(userId));
        }

        public UserResponse UpdateUser(Guid userId, UpdateUserRequest updateUserRequest)
        {
            return ConvertUser(_userRepoClient.UpdateUser(userId, updateUserRequest));
        }

        public bool DeleteUser(Guid userId)
        {
            return _userRepoClient.DeleteUser(userId);
        }

        private UserResponse ConvertUser(User userDomain)
        {
            if (userDomain == null)
            {
                return null;
            }
            UserResponse userResponse = new UserResponse
            {
                Id = userDomain.Id,
                Username = userDomain.Username,
                Password = userDomain.Password,
                FullName = userDomain.FullName,
                EmailAddress = userDomain.EmailAddress,
                HandicapIndex = userDomain.HandicapIndex,
                HomeCourseName = userDomain.HomeCourseName,
                Scores = userDomain.Scores,
                Posts = userDomain.Posts,
                GolfCourseId = userDomain.GolfCourseId,
            };

            return userResponse;
        }

        private List<UserResponse> ConvertUsers(IEnumerable<User> userDomains)
        {
            if (userDomains == null)
            {
                return null;
            }
            var userResponses = new List<UserResponse>();
            foreach (var userDomain in userDomains)
            {
                var userResponse = ConvertUser(userDomain);
                if (userResponse != null)
                {
                    userResponses.Add(userResponse);
                }
            }
            return userResponses;
        }
    }
}
