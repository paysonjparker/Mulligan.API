using Mulligan.API.Data;
using Mulligan.API.Models.DataTransferObjects.PostDto;
using Mulligan.API.Models.DataTransferObjects.ScoreDto;
using Mulligan.API.Models.DomainModels;

namespace Mulligan.API.Business
{
    public class PostService
    {
        private readonly MulliganDbContext _dbContext;

        public PostService(MulliganDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        
    }
}
