using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.GolfCourseRequests;
using Mulligan.API.Models.Responses;
using Mulligan.API.RepositoryServices.RepositoryClients;

namespace Mulligan.API.RepositoryServices
{
    public class GolfCourseRepoService : IGolfCourseRepoService
    {
        private readonly IGolfCourseRepoClient _golfCourseRepoClient;

        public GolfCourseRepoService(IGolfCourseRepoClient golfCourseRepoClient)
        {
            _golfCourseRepoClient = golfCourseRepoClient;
        }

        public GolfCourseResponse AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest)
        {
            return ConvertGolfCourse(_golfCourseRepoClient.AddGolfCourse(addGolfCourseRequest));
        }

        public IEnumerable<GolfCourseResponse> GetAllGolfCourses()
        {
            return ConvertGolfCourseList(_golfCourseRepoClient.GetAllGolfCourses());
        }

        public GolfCourseResponse GetGolfCourseById(int golfCourseId)
        {
            return ConvertGolfCourse(_golfCourseRepoClient.GetGolfCourseById(golfCourseId));
        }

        public bool DeleteGolfCourse(int golfCourseId)
        {
            return _golfCourseRepoClient.DeleteGolfCourse(golfCourseId);
        }

        public GolfCourseResponse UpdateGolfCourse(int golfCourseId, UpdateGolfCourseRequest golfCourseUpdateRequest )
        {
            return ConvertGolfCourse(_golfCourseRepoClient.UpdateGolfCourse(golfCourseId, golfCourseUpdateRequest));
        }

        private GolfCourseResponse ConvertGolfCourse(GolfCourse golfCourseDomain)
        {
            if (golfCourseDomain == null)
            {
                return null;
            }
            GolfCourseResponse golfCourseResponse = new GolfCourseResponse
            {
                Id = golfCourseDomain.Id,
                Name = golfCourseDomain.Name,
                City = golfCourseDomain.City,
                Subdivision = golfCourseDomain.Subdivision,
                Country = golfCourseDomain.Country,
                Yardage = golfCourseDomain.Yardage,
                Par = golfCourseDomain.Par,
                SlopeRating = golfCourseDomain.SlopeRating,
                CourseRating = golfCourseDomain.CourseRating,
                Users = ConvertUsers(golfCourseDomain.Users),
                Scores = ConvertScores(golfCourseDomain.Scores),
            };

            return golfCourseResponse;
        }

        private List<GolfCourseResponse> ConvertGolfCourseList(IEnumerable<GolfCourse> golfCourseDomains)
        {
            if (golfCourseDomains == null)
            {
                return null;
            }
            var golfCourseResponses = new List<GolfCourseResponse>();
            foreach (var golfCourseDomain in golfCourseDomains)
            {
                var golfCourseResponse = ConvertGolfCourse(golfCourseDomain);
                if (golfCourseResponse != null)
                {
                    golfCourseResponses.Add(golfCourseResponse);
                }
            }
            return golfCourseResponses;
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
