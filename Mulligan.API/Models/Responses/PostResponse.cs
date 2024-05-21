namespace Mulligan.API.Models.Responses
{
    public class PostResponse
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
    }
}
