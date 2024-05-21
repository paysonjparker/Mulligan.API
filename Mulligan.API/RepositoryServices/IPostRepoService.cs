using Mulligan.API.Models.Requests.PostRequests;
using Mulligan.API.Models.Responses;

namespace Mulligan.API.RepositoryServices
{
    public interface IPostRepoService
    {
        public PostResponse AddPost(AddPostRequest addPostRequest);
        public IEnumerable<PostResponse> GetAllPostsByUser(int userId);
        public IEnumerable<PostResponse> GetAllPosts();
        public bool DeletePost(int postId);
    }
}
