using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.GolfCourseRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public interface IGolfCourseRepoClient
    {
        public GolfCourse AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest);
        public List<GolfCourse> GetAllGolfCourses();
        public GolfCourse GetGolfCourseById(int id);
        public bool DeleteGolfCourse(int id);
        public GolfCourse UpdateGolfCourse(int id, UpdateGolfCourseRequest updateGolfCourseRequest);
        public List<GolfCourse> SearchGolfCourses(string? searchGolfCourseRequest);

    }
}
