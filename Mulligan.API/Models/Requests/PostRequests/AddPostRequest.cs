using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mulligan.API.Models.Requests.PostRequests
{
    [ExcludeFromCodeCoverage]
    public class AddPostRequest
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
