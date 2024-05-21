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
                Users = golfCourseDomain.Users,
                Scores = golfCourseDomain.Scores,
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
    }

}
