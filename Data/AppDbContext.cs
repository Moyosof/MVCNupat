using Microsoft.EntityFrameworkCore;
using MVCformNupat.Model;

namespace MVCformNupat.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
