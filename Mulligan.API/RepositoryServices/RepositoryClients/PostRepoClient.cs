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

        public Post AddPost(AddPostRequest addPostRequest)
        {
            var post = new Post
            {
                Content = addPostRequest.Content,
                CreatedDate = DateTime.Now,
                UserId = addPostRequest.UserId,
            };

            _dbContext.Post.Add(post);
            _dbContext.SaveChanges();

            return post;
        }

        public List<Post> GetAllPostsByUser(int userId)
        {
            var posts = _dbContext.Post.ToList().Where(post => post.UserId.Equals(userId)).ToList();

            return posts;
        }

        public List<Post> GetAllPosts()
        {
            var posts = _dbContext.Post.ToList();

            return posts;
        }

        public bool DeletePost(int id)
        {
            var post = _dbContext.Post.Find(id);

            if (post != null)
            {
                _dbContext.Post.Remove(post);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
