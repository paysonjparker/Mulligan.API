namespace Mulligan.API.Models.DomainModels
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid UserId { get; set; }
    }
}
