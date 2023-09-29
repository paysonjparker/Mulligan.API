using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mulligan.API.Business;
using Mulligan.API.Data;
using Mulligan.API.Models.DataTransferObjects.PostDto;
using Mulligan.API.Models.DataTransferObjects.ScoreDto;

namespace Mulligan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAngularOrigins")]
    public class PostsController : ControllerBase
    {
        private PostService _postService;

        public PostsController(MulliganDbContext dbContext)
        {
            this._postService = new PostService(dbContext);
        }

        [HttpPost]
        public IActionResult AddPost(AddPostRequest addPostRequest)
        {
            var post = _postService.AddPost(addPostRequest);

            return Ok(post);
        }

        [HttpGet]
        [Route("{userId:Guid}")]
        public IActionResult GetAllPostsByUser(Guid userId)
        {
            var posts = _postService.GetAllPostsByUser(userId);

            return Ok(posts);
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var posts = _postService.GetAllPosts();

            return Ok(posts);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeletePost(Guid id)
        {
            var existingPost = _postService.DeletePost(id);

            if (existingPost != false)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
