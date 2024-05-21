using Mulligan.API.Models.Requests.GolfCourseRequests;
using Mulligan.API.Models.Responses;
using Mulligan.API.RepositoryServices;

namespace Mulligan.API.BusinessServices
{
    public class GolfCourseBusinessService : IGolfCourseBusinessService
    {
        private readonly IGolfCourseRepoService _golfCourseRepoService;

        public GolfCourseBusinessService(IGolfCourseRepoService golfCourseRepoService)
        {
            _golfCourseRepoService = golfCourseRepoService;
        }

        public GolfCourseResponse AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest)
        {
            return _golfCourseRepoService.AddGolfCourse(addGolfCourseRequest);
        }

        public IEnumerable<GolfCourseResponse> GetAllGolfCourses()
        {
            return _golfCourseRepoService.GetAllGolfCourses();
        }

        public GolfCourseResponse GetGolfCourseById(int golfCourseId)
        {
            return _golfCourseRepoService.GetGolfCourseById(golfCourseId);
        }

        public bool DeleteGolfCourse(int golfCourseId)
        {
            return _golfCourseRepoService.DeleteGolfCourse(golfCourseId);
        }

        public GolfCourseResponse UpdateGolfCourse(int golfCourseId, UpdateGolfCourseRequest golfCourseUpdateRequest)
        {
            return _golfCourseRepoService.UpdateGolfCourse(golfCourseId, golfCourseUpdateRequest);
        }
    }
}
