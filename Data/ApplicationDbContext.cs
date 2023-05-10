using ConsoleApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<GamingPlatform> GamingPlatforms { get; set; }
    }
}
