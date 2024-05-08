using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.PostRequests;

namespace Mulligan.API.RepositoryServices.RepositoryClients
{
    public interface IPostRepoClient
    {
        public PostDomain AddPost(AddPostRequest addPostRequest);
        public List<PostDomain> GetAllPostsByUser(Guid userId);
        public List<PostDomain> GetAllPosts();
        public bool DeletePost(Guid id);
    }
}
