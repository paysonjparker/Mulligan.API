using Microsoft.EntityFrameworkCore;
using Mulligan.API.Models.Domain;

namespace Mulligan.API.Data
{
    public class MulliganDbContext : DbContext
    {
        public MulliganDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Score> Score { get; set; }
        public DbSet<GolfCourse> GolfCourse { get; set; }
        public DbSet<Post> Post { get; set; }
    }
}
