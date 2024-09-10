using Mulligan.API.Models.Authentication;
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

        public AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest)
        {
            return _userRepoClient.Authenticate(authenticateRequest);
        }

        public UserResponse AddUser(AddUserRequest addUserRequest)
        {
            return ConvertUser(_userRepoClient.AddUser(addUserRequest));
        }

        public IEnumerable<UserResponse> GetAllUsers()
        {
            return ConvertUsers(_userRepoClient.GetAllUsers());
        }

        public IEnumerable<UserResponse> GetAllUsersByGolfCourse(int golfCourseId)
        {
            return ConvertUsers(_userRepoClient.GetAllUsersByGolfCourse(golfCourseId));
        }

        public UserResponse GetUserById(int userId)
        {
            return ConvertUser(_userRepoClient.GetUserById(userId));
        }

        public UserResponse UpdateUser(int userId, UpdateUserRequest updateUserRequest)
        {
            return ConvertUser(_userRepoClient.UpdateUser(userId, updateUserRequest));
        }

        public bool DeleteUser(int userId)
        {
            return _userRepoClient.DeleteUser(userId);
        }

        public IEnumerable<UserResponse> SearchUsers(string? searchUserRequest)
        {
            return ConvertUsers(_userRepoClient.SearchUsers(searchUserRequest));
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
                Scores = ConvertScores(userDomain.Scores),
                Posts = ConvertPosts(userDomain.Posts),
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

        private ScoreResponse ConvertScore(Score scoreDomain)
        {
            if (scoreDomain == null)
            {
                return null;
            }
            ScoreResponse scoreResponse = new ScoreResponse
            {
                Id = scoreDomain.Id,
                Differential = scoreDomain.Differential,
                Total = scoreDomain.Total,
                CreatedDate = scoreDomain.CreatedDate,
                UserId = scoreDomain.UserId,
                GolfCourseId = scoreDomain.GolfCourseId,
            };

            return scoreResponse;
        }

        private List<ScoreResponse> ConvertScores(IEnumerable<Score> scoreDomains)
        {
            if (scoreDomains == null)
            {
                return null;
            }
            var scoreResponses = new List<ScoreResponse>();
            foreach (var scoreDomain in scoreDomains)
            {
                var scoreResponse = ConvertScore(scoreDomain);
                if (scoreResponse != null)
                {
                    scoreResponses.Add(scoreResponse);
                }
            }
            return scoreResponses;
        }

        private PostResponse ConvertPost(Post postDomain)
        {
            if (postDomain == null)
            {
                return null;
            }
            PostResponse postResponse = new PostResponse
            {
                Id = postDomain.Id,
                Content = postDomain.Content,
                CreatedDate = postDomain.CreatedDate,
                UserId = postDomain.UserId,
            };

            return postResponse;
        }

        private List<PostResponse> ConvertPosts(IEnumerable<Post> postDomains)
        {
            if (postDomains == null)
            {
                return null;
            }
            var postResponses = new List<PostResponse>();
            foreach (var postDomain in postDomains)
            {
                var postResponse = ConvertPost(postDomain);
                if (postResponse != null)
                {
                    postResponses.Add(postResponse);
                }
            }
            return postResponses;
        }
    }
}
