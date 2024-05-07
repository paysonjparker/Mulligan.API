using System.ComponentModel.DataAnnotations;

namespace Mulligan.API.Models.Requests.PostRequests
{
    public class AddPostRequest
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
