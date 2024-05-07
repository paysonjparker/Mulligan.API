namespace Mulligan.API.Models.Responses
{
    public class PostResponse
    {
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
    }
}
