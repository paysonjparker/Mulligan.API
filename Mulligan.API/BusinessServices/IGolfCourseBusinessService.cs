using Mulligan.API.Models.Requests.GolfCourseRequests;
using Mulligan.API.Models.Responses;

namespace Mulligan.API.BusinessServices
{
    public interface IGolfCourseBusinessService
    {
        public GolfCourseResponse? AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest);
        public IEnumerable<GolfCourseResponse>? GetAllGolfCourses();
        public GolfCourseResponse? GetGolfCourseById(Guid golfCourseId);
        public bool DeleteGolfCourse(Guid golfCourseId);
        public GolfCourseResponse? UpdateGolfCourse(Guid golfCourseId, UpdateGolfCourseRequest golfCourseUpdateRequest);
    }
}
