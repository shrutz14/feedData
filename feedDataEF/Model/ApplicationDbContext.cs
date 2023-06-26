using Microsoft.EntityFrameworkCore;

namespace feedDataEF.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<employee> employees { get; set; }
        public DbSet<department> department { get; set; }
    }
}
