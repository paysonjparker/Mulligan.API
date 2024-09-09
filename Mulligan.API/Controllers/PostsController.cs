using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mulligan.API.Authorization;
using Mulligan.API.BusinessServices;
using Mulligan.API.Models.Requests.PostRequests;

namespace Mulligan.API.Controllers
{
    //[Authorize]
    [Route("api/posts")]
    [ApiController]
    [EnableCors("AllowAngularOrigins")]
    public class PostsController : ControllerBase
    {
        private IPostBusinessService _postBusinessService;

        public PostsController(IPostBusinessService postBusinessService)
        {
            _postBusinessService = postBusinessService;
        }

        [HttpPost]
        public IActionResult AddPost(AddPostRequest addPostRequest)
        {
            try
            {
                var createdPost = _postBusinessService.AddPost(addPostRequest);

                return Created("", createdPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("user/{userId:int}")]
        public IActionResult GetAllPostsByUser(int userId)
        {
            try
            {
                var posts = _postBusinessService.GetAllPostsByUser(userId);

                if (posts == null)
                {
                    return NotFound();
                }
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            try
            {
                var posts = _postBusinessService.GetAllPosts();

                if (posts == null)
                {
                    return NotFound();
                }
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{postId:int}")]
        public IActionResult DeletePost(int postId)
        {
            try
            {
                var deletedPost = _postBusinessService.DeletePost(postId);

                if (deletedPost != false)
                {
                    return NoContent();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
