using Mulligan.API.Data;
using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.PostRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public class PostRepoClient : IPostRepoClient
    {
        private readonly MulliganDbContext _dbContext;

        public PostRepoClient(MulliganDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public PostDomain AddPost(AddPostRequest addPostRequest)
        {
            var post = new PostDomain
            {
                CONTENT = addPostRequest.Content,
                CREATED_DATE = DateTime.Now,
                USER_ID = addPostRequest.UserId,
            };

            _dbContext.POST.Add(post);
            _dbContext.SaveChanges();

            return post;
        }

        public List<PostDomain> GetAllPostsByUser(Guid userId)
        {
            var posts = _dbContext.POST.ToList().Where(post => post.USER_ID.Equals(userId)).ToList();

            return posts;
        }

        public List<PostDomain> GetAllPosts()
        {
            var posts = _dbContext.POST.ToList();

            return posts;
        }

        public bool DeletePost(Guid id)
        {
            var post = _dbContext.POST.Find(id);

            if (post != null)
            {
                _dbContext.POST.Remove(post);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
