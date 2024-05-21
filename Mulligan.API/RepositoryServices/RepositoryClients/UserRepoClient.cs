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

        public User AddUser(AddUserRequest addUserRequest)
        {
            var homeCourse = _dbContext.GolfCourse.Find(addUserRequest.GolfCourseId);
            string homeCourseName = null;

            if (homeCourse != null)
            {
                homeCourseName = homeCourse.Name;
            }
            var user = new User
            {
                Username = addUserRequest.Username,
                Password = addUserRequest.Password,
                FullName = addUserRequest.FullName,
                EmailAddress = addUserRequest.EmailAddress,
                HandicapIndex = 0,
                HomeCourseName = homeCourseName ?? null,
                GolfCourseId = addUserRequest.GolfCourseId ?? null,
            };

            _dbContext.User.Add(user);
            _dbContext.SaveChanges();

            return user;
        }

        public List<User> GetAllUsers()
        {
            var users = _dbContext.User.ToList();

            foreach (var user in users)
            {
                user.Posts = _dbContext.Post.ToList().Where(post => post.UserId.Equals(user.Id)).ToList();
                user.Scores = _dbContext.Score.ToList().Where(score => score.UserId.Equals(user.Id)).ToList();
            }

            return users;
        }

        public List<User> GetAllUsersByGolfCourse(int golfCourseId)
        {
            var users = _dbContext.User.Where(user => user.GolfCourseId.Equals(golfCourseId)).ToList();

            foreach (var user in users)
            {
                user.Posts = _dbContext.Post.ToList().Where(post => post.UserId.Equals(user.Id)).ToList();
                user.Scores = _dbContext.Score.ToList().Where(score => score.UserId.Equals(user.Id)).ToList();
            }

            return users;
        }

        public User GetUserById(int id)
        {
            var user = _dbContext.User.Find(id);

            if (user != null)
            {                
                user.Posts = _dbContext.Post.ToList().Where(post => post.UserId.Equals(user.Id)).ToList();
                user.Scores = _dbContext.Score.ToList().Where(score => score.UserId.Equals(user.Id)).ToList();
                return user;
            }

            return null;
        }

        public User UpdateUser(int id, UpdateUserRequest updateUserRequest)
        {
            var user = _dbContext.User.Find(id);
            var homeCourse = _dbContext.GolfCourse.Find(updateUserRequest.GolfCourseId);

            if (user != null)
            {
                user.Password = updateUserRequest.Password ?? user.Password;
                user.FullName = updateUserRequest.FullName;
                user.EmailAddress = updateUserRequest.EmailAddress;
                user.HomeCourseName = homeCourse.Name ?? null;
                user.GolfCourseId = updateUserRequest.GolfCourseId ?? null;

                _dbContext.SaveChanges();
                return user;
            }

            return null;
        }

        public bool DeleteUser(int id)
        {
            var user = _dbContext.User.Find(id);

            if (user != null)
            {
                _dbContext.User.Remove(user);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

    }
}
