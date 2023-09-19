namespace Mulligan.API.Models.DataTransferObjects.PostDto
{
    public class AddPostRequest
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
    }
}
