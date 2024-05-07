using System.ComponentModel.DataAnnotations;

namespace Mulligan.API.Models.Domain
{
    public class PostDomain
    {
        [Key]
        public Guid POST_ID { get; set; }
        public string CONTENT { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public Guid USER_ID { get; set; }
    }
}
