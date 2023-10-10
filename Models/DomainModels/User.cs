namespace Mulligan.API.Models.DomainModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public float HandicapIndex { get; set; }
        public string HomeCourseName { get; set; }
        public ICollection<Score> Scores { get; set; }
        public ICollection<Post> Posts { get; set; }
        public Guid GolfCourseId { get; set; }

    }
}
