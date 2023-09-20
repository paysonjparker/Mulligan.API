using Mulligan.API.Data;
using Mulligan.API.Models.DataTransferObjects.UserDto;
using Mulligan.API.Models.DomainModels;

namespace Mulligan.API.Business
{
    public class UserService
    {
        private readonly MulliganDbContext _dbContext;

        public UserService(MulliganDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        

    }
}
