using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mulligan.API.Models.Domain
{
    [ExcludeFromCodeCoverage]
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
