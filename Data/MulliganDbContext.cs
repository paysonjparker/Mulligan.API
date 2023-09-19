using Microsoft.EntityFrameworkCore;
using Mulligan.API.Models.DomainModels;

namespace Mulligan.API.Data
{
    public class MulliganDbContext : DbContext
    {
        public MulliganDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<GolfCourse> GolfCourses { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
