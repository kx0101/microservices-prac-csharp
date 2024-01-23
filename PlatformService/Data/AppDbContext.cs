using microservice_prac.Models;
using Microsoft.EntityFrameworkCore;

namespace microservice_prac.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Platform> Platform { get; set; }
    }
}
