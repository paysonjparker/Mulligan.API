using AutoMapper;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Mulligan.API.Authorization;
using Mulligan.API.Data;
using Mulligan.API.Helpers;
using Mulligan.API.Models.Authentication;
using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.UserRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public class UserRepoClient : IUserRepoClient
    {
        private readonly MulliganDbContext _dbContext;
        private IJwtUtils _jwtUtils;

        public UserRepoClient(MulliganDbContext dbContext, IJwtUtils jwtUtils)
        {
            this._dbContext = dbContext;
            _jwtUtils = jwtUtils;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest)
        {
            var user = _dbContext.User.SingleOrDefault(user => user.Username == authenticateRequest.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(authenticateRequest.Password, user.Password))
            {
                throw new Exception("Useranme or Password is incorrect");
            }
            var response = new AuthenticateResponse()
            {
                Id = user.Id,
                Username = user.Username,
                FullName = user.FullName,
                Token = _jwtUtils.GenerateToken(user),
            };
            return response;
        }

        public User AddUser(AddUserRequest addUserRequest)
        {
            if (_dbContext.User.Any(user => user.Username == addUserRequest.Username))
            {
                throw new AppException("Username '" + addUserRequest.Username + "' is already taken");
            }

            var homeCourse = _dbContext.GolfCourse.Find(addUserRequest.GolfCourseId);
            string homeCourseName = null;

            if (homeCourse != null)
            {
                homeCourseName = homeCourse.Name;
            }
            var user = new User
            {
                Username = addUserRequest.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(addUserRequest.Password),
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
                user.Password = BCrypt.Net.BCrypt.HashPassword(updateUserRequest.Password) ?? user.Password;
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
