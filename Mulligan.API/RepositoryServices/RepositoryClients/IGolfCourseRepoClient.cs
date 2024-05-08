using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.GolfCourseRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public interface IGolfCourseRepoClient
    {
        public GolfCourse AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest);
        public List<GolfCourse> GetAllGolfCourses();
        public GolfCourse GetGolfCourseById(Guid id);
        public bool DeleteGolfCourse(Guid id);
        public GolfCourse UpdateGolfCourse(Guid id, UpdateGolfCourseRequest updateGolfCourseRequest);
    }
}
