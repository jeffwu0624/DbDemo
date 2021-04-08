using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repo
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }

    
}
