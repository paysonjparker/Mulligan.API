using Mulligan.API.Models.Requests.PostRequests;
using Mulligan.API.Models.Responses;
using Mulligan.API.RepositoryServices;

namespace Mulligan.API.BusinessServices
{
    public class PostBusinessService : IPostBusinessService
    {
        private readonly IPostRepoService _postRepoService;

        public PostBusinessService(IPostRepoService postRepoService)
        {
            _postRepoService = postRepoService;
        }

        public PostResponse AddPost(AddPostRequest addPostRequest)
        {
            return _postRepoService.AddPost(addPostRequest);
        }

        public IEnumerable<PostResponse> GetAllPostsByUser(int userId)
        {
            return _postRepoService.GetAllPostsByUser(userId);
        }

        public IEnumerable<PostResponse> GetAllPosts()
        {
            return _postRepoService.GetAllPosts();
        }

        public bool DeletePost(int postId) 
        {
            return _postRepoService.DeletePost(postId);
        }
    }
}
