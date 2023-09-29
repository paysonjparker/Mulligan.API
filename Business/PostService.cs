using Mulligan.API.Data;
using Mulligan.API.Models.DataTransferObjects.PostDto;
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

        public Post AddPost(AddPostRequest addPostRequest)
        {

            var post = new Post 
            {
                Content = addPostRequest.Content,
                Timestamp = DateTime.Now,
                UserId = addPostRequest.UserId,
            };

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();

            return post;
        }

        public List<Post> GetAllPostsByUser(Guid userId)
        {

            var posts = _dbContext.Posts.ToList();

            var postsDto = new List<Post>();
            foreach (var post in posts)
            {
                if (post.UserId == userId)
                {
                    postsDto.Add(new Post
                    {
                        Id = post.Id,
                        Content = post.Content,
                        Timestamp = post.Timestamp,
                        UserId = post.UserId,
                    });
                }
            }

            return postsDto;
        }

        public List<Post> GetAllPosts()
        {

            var posts = _dbContext.Posts.ToList();

            var postsDto = new List<Post>();
            foreach (var post in posts)
            {
                postsDto.Add(new Post
                {
                    Id = post.Id,
                    Content = post.Content,
                    Timestamp = post.Timestamp,
                    UserId = post.UserId,
                });
            }

            return postsDto;
        }

        public bool DeletePost(Guid id)
        {
            var existingPost = _dbContext.Posts.Find(id);

            if (existingPost != null)
            {
                _dbContext.Posts.Remove(existingPost);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
