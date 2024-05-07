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

        public GolfCourseResponse GetGolfCourseById(Guid golfCourseId)
        {
            return ConvertGolfCourse(_golfCourseRepoClient.GetGolfCourseById(golfCourseId));
        }

        public bool DeleteGolfCourse(Guid golfCourseId)
        {
            return _golfCourseRepoClient.DeleteGolfCourse(golfCourseId);
        }

        public GolfCourseResponse UpdateGolfCourse(Guid golfCourseId, UpdateGolfCourseRequest golfCourseUpdateRequest )
        {
            return ConvertGolfCourse(_golfCourseRepoClient.UpdateGolfCourse(golfCourseId, golfCourseUpdateRequest));
        }

        private GolfCourseResponse ConvertGolfCourse(GolfCourseDomain golfCourseDomain)
        {
            if (golfCourseDomain == null)
            {
                return null;
            }
            GolfCourseResponse golfCourseResponse = new GolfCourseResponse
            {
                GolfCourseId = golfCourseDomain.GOLF_COURSE_ID,
                Name = golfCourseDomain.NAME,
                City = golfCourseDomain.CITY,
                Subdivision = golfCourseDomain.SUBDIVISION,
                Country = golfCourseDomain.COUNTRY,
                Yardage = golfCourseDomain.YARDAGE,
                Par = golfCourseDomain.PAR,
                SlopeRating = golfCourseDomain.SLOPE_RATING,
                CourseRating = golfCourseDomain.COURSE_RATING,
                Users = golfCourseDomain.USERS,
                Scores = golfCourseDomain.SCORES,
            };

            return golfCourseResponse;
        }

        private List<GolfCourseResponse> ConvertGolfCourseList(IEnumerable<GolfCourseDomain> golfCourseDomains)
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
