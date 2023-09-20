using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Mulligan.API.Data;
using Mulligan.API.Models.DataTransferObjects.UserDto;
using Mulligan.API.Models.DomainModels;
using System.Security.Cryptography;

namespace Mulligan.API.Business
{
    public class UserService
    {
        private readonly MulliganDbContext _dbContext;

        public UserService(MulliganDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public User AddUser(AddUserRequest addUserRequest)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes


            var user = new User
            {
                Username = addUserRequest.Username,
                Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: addUserRequest.Password,
                            salt: salt,
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 100000,
                            numBytesRequested: 256 / 8)),
                Name = addUserRequest.Name,
                Email = addUserRequest.Email,
                HandicapIndex = 0,
                GolfCourseId = addUserRequest.GolfCourseId,
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user;
        }

    }
}
