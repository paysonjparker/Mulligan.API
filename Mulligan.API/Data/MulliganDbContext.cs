using Microsoft.EntityFrameworkCore;
using Mulligan.API.Models.Domain;

namespace Mulligan.API.Data
{
    public class MulliganDbContext : DbContext
    {
        public MulliganDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserDomain> USER { get; set; }
        public DbSet<ScoreDomain> SCORE { get; set; }
        public DbSet<GolfCourseDomain> GOLF_COURSE { get; set; }
        public DbSet<PostDomain> POST { get; set; }
    }
}
