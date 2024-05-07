namespace Mulligan.API.Models.Responses
{
    public class PostResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid UserId { get; set; }
    }
}
