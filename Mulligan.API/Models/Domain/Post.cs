using System.ComponentModel.DataAnnotations;

namespace Mulligan.API.Models.Domain
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
