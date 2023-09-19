using Mulligan.API.Data;

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
