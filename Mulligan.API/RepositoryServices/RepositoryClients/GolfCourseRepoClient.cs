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
        public GolfCourseDomain AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest)
        {
            // Convert DTO to Domain Model
            var golfCourse = new GolfCourseDomain
            {
                NAME = addGolfCourseRequest.Name,
                CITY = addGolfCourseRequest.City,
                SUBDIVISION = addGolfCourseRequest.Subdivision,
                COUNTRY = addGolfCourseRequest.Country,
                YARDAGE = addGolfCourseRequest.Yardage,
                PAR = addGolfCourseRequest.Par,
                SLOPE_RATING = addGolfCourseRequest.SlopeRating,
                COURSE_RATING = addGolfCourseRequest.CourseRating,
            };

            _dbContext.GOLF_COURSE.Add(golfCourse);
            _dbContext.SaveChanges();

            return golfCourse;
        }

        /// <summary>
        /// Gets all golf courses from the golf course table
        /// </summary>
        /// <returns>A list of golf courses</returns>
        public List<GolfCourseDomain> GetAllGolfCourses()
        {
            var golfCourses = _dbContext.GOLF_COURSE.ToList();

            foreach (var golfCourse in golfCourses)
            {
                golfCourse.SCORES = _dbContext.SCORE.Where(score => score.GOLF_COURSE_ID.Equals(golfCourse.GOLF_COURSE_ID)).ToList();
                golfCourse.USERS = _dbContext.USER.Where(user => user.GOLF_COURSE_ID.Equals(golfCourse.GOLF_COURSE_ID)).ToList();
            }

            return golfCourses;
        }

        /// <summary>
        /// Gets a specific golf course by ID number
        /// </summary>
        /// <param name="id">ID of the golf course</param>
        /// <returns>A golf course object</returns>
        public GolfCourseDomain GetGolfCourseById(Guid id)
        {
            var golfCourse = _dbContext.GOLF_COURSE.Find(id);

            if (golfCourse != null)
            {
                golfCourse.SCORES = _dbContext.SCORE.Where(score => score.GOLF_COURSE_ID.Equals(golfCourse.GOLF_COURSE_ID)).ToList();
                golfCourse.USERS = _dbContext.USER.Where(user => user.GOLF_COURSE_ID.Equals(golfCourse.GOLF_COURSE_ID)).ToList();

                return golfCourse;
            }

            return null;
        }

        public bool DeleteGolfCourse(Guid id)
        {
            var golfCourse = _dbContext.GOLF_COURSE.Find(id);

            if (golfCourse != null)
            {
                _dbContext.GOLF_COURSE.Remove(golfCourse);
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
        public GolfCourseDomain UpdateGolfCourse(Guid id, UpdateGolfCourseRequest updateGolfCourseRequest)
        {
            var golfCourse = _dbContext.GOLF_COURSE.Find(id);

            if (golfCourse != null)
            {
                golfCourse.NAME = updateGolfCourseRequest.Name ?? golfCourse.NAME;
                golfCourse.CITY = updateGolfCourseRequest.City ?? golfCourse.CITY;
                golfCourse.SUBDIVISION = updateGolfCourseRequest.Subdivision ?? golfCourse.SUBDIVISION;
                golfCourse.COUNTRY = updateGolfCourseRequest.Country ?? golfCourse.COUNTRY;
                golfCourse.YARDAGE = updateGolfCourseRequest.Yardage ?? golfCourse.YARDAGE;
                golfCourse.PAR = updateGolfCourseRequest.Par ?? golfCourse.PAR;
                golfCourse.SLOPE_RATING = updateGolfCourseRequest.SlopeRating ?? golfCourse.SLOPE_RATING;
                golfCourse.COURSE_RATING = updateGolfCourseRequest.CourseRating ?? golfCourse.COURSE_RATING;

                _dbContext.SaveChanges();
                return golfCourse;
            }

            return null;
        }
    }
}
