using Mulligan.API.Models.Requests.GolfCourseRequests;
using Mulligan.API.Models.Responses;

namespace Mulligan.API.RepositoryServices
{
    public interface IGolfCourseRepoService
    {
        public GolfCourseResponse AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest);
        public IEnumerable<GolfCourseResponse> GetAllGolfCourses();
        public GolfCourseResponse GetGolfCourseById(int golfCourseId);
        public bool DeleteGolfCourse(int golfCourseId);
        public GolfCourseResponse UpdateGolfCourse(int golfCourseId, UpdateGolfCourseRequest golfCourseUpdateRequest);
        public IEnumerable<GolfCourseResponse> SearchGolfCourses(string? searchGolfCourseRequest);
    }
}
