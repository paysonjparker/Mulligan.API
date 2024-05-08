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

        private UserResponse ConvertUser(UserDomain userDomain)
        {
            if (userDomain == null)
            {
                return null;
            }
            UserResponse userResponse = new UserResponse
            {
                UserId = userDomain.USER_ID,
                Username = userDomain.USERNAME,
                Password = userDomain.PASSWORD,
                FullName = userDomain.FULL_NAME,
                EmailAddress = userDomain.EMAIL_ADDRESS,
                HandicapIndex = userDomain.HANDICAP_INDEX,
                HomeCourseName = userDomain.HOME_COURSE_NAME,
                Scores = userDomain.SCORES,
                Posts = userDomain.POSTS,
                GolfCourseId = userDomain.GOLF_COURSE_ID,
            };

            return userResponse;
        }

        private List<UserResponse> ConvertUsers(IEnumerable<UserDomain> userDomains)
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
