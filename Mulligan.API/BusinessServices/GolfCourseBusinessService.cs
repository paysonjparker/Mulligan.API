using Mulligan.API.Models.Requests.GolfCourseRequests;
using Mulligan.API.Models.Responses;
using Mulligan.API.RepositoryServices;

namespace Mulligan.API.BusinessServices
{
    public class GolfCourseBusinessService : IGolfCourseBusinessService
    {
        // Db Context
        private readonly IGolfCourseRepoService _golfCourseRepoService;

        /// <summary>
        /// Constrcutor 
        /// </summary>
        public GolfCourseBusinessService(IGolfCourseRepoService golfCourseRepoService)
        {
            _golfCourseRepoService = golfCourseRepoService;
        }

        public GolfCourseResponse? AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest)
        {
            return _golfCourseRepoService.AddGolfCourse(addGolfCourseRequest);
        }

        public IEnumerable<GolfCourseResponse>? GetAllGolfCourses()
        {
            return _golfCourseRepoService.GetAllGolfCourses();
        }

        public GolfCourseResponse? GetGolfCourseById(Guid golfCourseId)
        {
            return _golfCourseRepoService.GetGolfCourseById(golfCourseId);
        }

        public bool DeleteGolfCourse(Guid golfCourseId)
        {
            return _golfCourseRepoService.DeleteGolfCourse(golfCourseId);
        }

        public GolfCourseResponse? UpdateGolfCourse(Guid golfCourseId, UpdateGolfCourseRequest golfCourseUpdateRequest)
        {
            return _golfCourseRepoService.UpdateGolfCourse(golfCourseId, golfCourseUpdateRequest);
        }
    }
}
