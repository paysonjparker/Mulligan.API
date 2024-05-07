using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.GolfCourseRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public interface IGolfCourseRepoClient
    {
        public GolfCourseDomain AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest);
        public List<GolfCourseDomain> GetAllGolfCourses();
        public GolfCourseDomain GetGolfCourseById(Guid id);
        public bool DeleteGolfCourse(Guid id);
        public GolfCourseDomain UpdateGolfCourse(Guid id, UpdateGolfCourseRequest updateGolfCourseRequest);
    }
}
