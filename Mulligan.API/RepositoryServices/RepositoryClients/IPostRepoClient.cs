using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.PostRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public interface IPostRepoClient
    {
        public Post AddPost(AddPostRequest addPostRequest);
        public List<Post> GetAllPostsByUser(int userId);
        public List<Post> GetAllPosts();
        public bool DeletePost(int id);
    }
}
