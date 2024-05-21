using Mulligan.API.Data;
using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.GolfCourseRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public class GolfCourseRepoClient : IGolfCourseRepoClient
    {
        private readonly MulliganDbContext _dbContext;

        /// <summary>
        /// Constrcutor with dbContext injection
        /// </summary>
        /// <param name="dbContext">DB Context</param>
        public GolfCourseRepoClient(MulliganDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Adds a new golf course to the golf course table
        /// </summary>
        /// <param name="addGolfCourseRequest">Golf course request</param>
        /// <returns></returns>
        public GolfCourse AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest)
        {
            // Convert DTO to Domain Model
            var golfCourse = new GolfCourse
            {
                Name = addGolfCourseRequest.Name,
                City = addGolfCourseRequest.City,
                Subdivision = addGolfCourseRequest.Subdivision,
                Country = addGolfCourseRequest.Country,
                Yardage = addGolfCourseRequest.Yardage,
                Par = addGolfCourseRequest.Par,
                SlopeRating = addGolfCourseRequest.SlopeRating,
                CourseRating = addGolfCourseRequest.CourseRating,
            };

            _dbContext.GolfCourse.Add(golfCourse);
            _dbContext.SaveChanges();

            return golfCourse;
        }

        /// <summary>
        /// Gets all golf courses from the golf course table
        /// </summary>
        /// <returns>A list of golf courses</returns>
        public List<GolfCourse> GetAllGolfCourses()
        {
            var golfCourses = _dbContext.GolfCourse.ToList();

            foreach (var golfCourse in golfCourses)
            {
                golfCourse.Scores = _dbContext.Score.Where(score => score.GolfCourseId.Equals(golfCourse.Id)).ToList();
                golfCourse.Users = _dbContext.User.Where(user => user.GolfCourseId.Equals(golfCourse.Id)).ToList();
            }

            return golfCourses;
        }

        /// <summary>
        /// Gets a specific golf course by ID number
        /// </summary>
        /// <param name="id">ID of the golf course</param>
        /// <returns>A golf course object</returns>
        public GolfCourse GetGolfCourseById(int id)
        {
            var golfCourse = _dbContext.GolfCourse.Find(id);

            if (golfCourse != null)
            {
                golfCourse.Scores = _dbContext.Score.Where(score => score.GolfCourseId.Equals(golfCourse.Id)).ToList();
                golfCourse.Users = _dbContext.User.Where(user => user.GolfCourseId.Equals(golfCourse.Id)).ToList();

                return golfCourse;
            }

            return null;
        }

        public bool DeleteGolfCourse(int id)
        {
            var golfCourse = _dbContext.GolfCourse.Find(id);

            if (golfCourse != null)
            {
                _dbContext.GolfCourse.Remove(golfCourse);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates an exisitng golf course in the database
        /// </summary>
        /// <param name="id">ID number of the golf course being updated</param>
        /// <param name="updateGolfCourseRequest">Update golf course request</param>
        /// <returns>The newly updated golf course object</returns>
        public GolfCourse UpdateGolfCourse(int id, UpdateGolfCourseRequest updateGolfCourseRequest)
        {
            var golfCourse = _dbContext.GolfCourse.Find(id);

            if (golfCourse != null)
            {
                golfCourse.Name = updateGolfCourseRequest.Name ?? golfCourse.Name;
                golfCourse.City = updateGolfCourseRequest.City ?? golfCourse.City;
                golfCourse.Subdivision = updateGolfCourseRequest.Subdivision ?? golfCourse.Subdivision;
                golfCourse.Country = updateGolfCourseRequest.Country ?? golfCourse.Country;
                golfCourse.Yardage = updateGolfCourseRequest.Yardage ?? golfCourse.Yardage;
                golfCourse.Par = updateGolfCourseRequest.Par ?? golfCourse.Par;
                golfCourse.SlopeRating = updateGolfCourseRequest.SlopeRating ?? golfCourse.SlopeRating;
                golfCourse.CourseRating = updateGolfCourseRequest.CourseRating ?? golfCourse.CourseRating;

                _dbContext.SaveChanges();
                return golfCourse;
            }

            return null;
        }
    }
}
