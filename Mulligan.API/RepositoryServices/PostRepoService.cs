using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.PostRequests;
using Mulligan.API.Models.Responses;
using Mulligan.API.RepositoryServices.RepositoryClients;

namespace Mulligan.API.RepositoryServices
{
    public class PostRepoService : IPostRepoService
    {
        private readonly IPostRepoClient _postRepoClient;

        public PostRepoService(IPostRepoClient postRepoClient)
        {
            _postRepoClient = postRepoClient;
        }

        public PostResponse AddPost(AddPostRequest addPostRequest)
        {
            return ConvertPost(_postRepoClient.AddPost(addPostRequest));
        }

        public IEnumerable<PostResponse> GetAllPostsByUser(Guid userId)
        {
            return ConvertPosts(_postRepoClient.GetAllPostsByUser(userId));
        }

        public IEnumerable<PostResponse> GetAllPosts()
        {
            return ConvertPosts(_postRepoClient.GetAllPosts());
        }

        public bool DeletePost(Guid postId)
        {
            return _postRepoClient.DeletePost(postId);
        }

        private PostResponse ConvertPost(PostDomain postDomain)
        {
            if(postDomain == null)
            {
                return null;
            }
            PostResponse postResponse = new PostResponse
            {
                PostId = postDomain.POST_ID,
                Content = postDomain.CONTENT,
                CreatedDate = postDomain.CREATED_DATE,
                UserId = postDomain.USER_ID,
            };

            return postResponse;
        }

        private List<PostResponse> ConvertPosts(IEnumerable<PostDomain> postDomains)
        {
            if(postDomains == null)
            {
                return null;
            }
            var postResponses = new List<PostResponse>();
            foreach (var postDomain in postDomains)
            {
                var postResponse = ConvertPost(postDomain);
                if(postResponse != null)
                {
                    postResponses.Add(postResponse);
                }
            }
            return postResponses;
        }
    }
}
