using Mulligan.API.Models.Requests.GolfCourseRequests;
using Mulligan.API.Models.Requests.UserRequests;
using Mulligan.API.Models.Responses;

namespace Mulligan.API.BusinessServices
{
    public interface IGolfCourseBusinessService
    {
        public GolfCourseResponse AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest);
        public IEnumerable<GolfCourseResponse> GetAllGolfCourses();
        public GolfCourseResponse GetGolfCourseById(int golfCourseId);
        public bool DeleteGolfCourse(int golfCourseId);
        public GolfCourseResponse UpdateGolfCourse(int golfCOurseId, UpdateGolfCourseRequest updateGolfCourseRequest);
        public IEnumerable<GolfCourseResponse> SearchGolfCourses(string? searchGolfCourseRequest);

    }
}
