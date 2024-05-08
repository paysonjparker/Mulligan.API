using Mulligan.API.BusinessServices;
using Mulligan.API.Data;
using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.UserRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public class UserRepoClient : IUserRepoClient
    {
        private readonly MulliganDbContext _dbContext;

        public UserRepoClient(MulliganDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public UserDomain AddUser(AddUserRequest addUserRequest)
        {
            var homeCourse = _dbContext.GOLF_COURSE.Find(addUserRequest.GolfCourseId);

            var user = new UserDomain
            {
                USERNAME = addUserRequest.Username,
                PASSWORD = addUserRequest.Password,
                FULL_NAME = addUserRequest.FullName,
                EMAIL_ADDRESS = addUserRequest.EmailAddress,
                HANDICAP_INDEX = 0,
                HOME_COURSE_NAME = homeCourse.NAME ?? null,
                GOLF_COURSE_ID = addUserRequest.GolfCourseId ?? null,
            };

            _dbContext.USER.Add(user);
            _dbContext.SaveChanges();

            return user;
        }

        public List<UserDomain> GetAllUsers()
        {
            var users = _dbContext.USER.ToList();

            foreach (var user in users)
            {
                user.POSTS = _dbContext.POST.ToList().Where(post => post.USER_ID.Equals(user.USER_ID)).ToList();
                user.SCORES = _dbContext.SCORE.ToList().Where(score => score.USER_ID.Equals(user.USER_ID)).ToList();
            }

            return users;
        }

        public List<UserDomain> GetAllUsersByGolfCourse(Guid golfCourseId)
        {
            var users = _dbContext.USER.Where(user => user.GOLF_COURSE_ID.Equals(golfCourseId)).ToList();

            foreach (var user in users)
            {
                user.POSTS = _dbContext.POST.ToList().Where(post => post.USER_ID.Equals(user.USER_ID)).ToList();
                user.SCORES = _dbContext.SCORE.ToList().Where(score => score.USER_ID.Equals(user.USER_ID)).ToList();
            }

            return users;
        }

        public UserDomain GetUserById(Guid id)
        {
            var user = _dbContext.USER.Find(id);

            if (user != null)
            {                
                user.POSTS = _dbContext.POST.ToList().Where(post => post.USER_ID.Equals(user.USER_ID)).ToList();
                user.SCORES = _dbContext.SCORE.ToList().Where(score => score.USER_ID.Equals(user.USER_ID)).ToList();
                return user;
            }

            return null;
        }

        public UserDomain UpdateUser(Guid id, UpdateUserRequest updateUserRequest)
        {
            var user = _dbContext.USER.Find(id);
            var homeCourse = _dbContext.GOLF_COURSE.Find(updateUserRequest.GolfCourseId);

            if (user != null)
            {
                user.PASSWORD = updateUserRequest.Password ?? user.PASSWORD;
                user.FULL_NAME = updateUserRequest.FullName;
                user.EMAIL_ADDRESS = updateUserRequest.EmailAddress;
                user.HOME_COURSE_NAME = homeCourse.NAME ?? null;
                user.GOLF_COURSE_ID = updateUserRequest.GolfCourseId ?? null;

                _dbContext.SaveChanges();
                return user;
            }

            return null;
        }

        public bool DeleteUser(Guid id)
        {
            var user = _dbContext.USER.Find(id);

            if (user != null)
            {
                _dbContext.USER.Remove(user);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

    }
}
