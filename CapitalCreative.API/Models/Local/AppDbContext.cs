using Microsoft.EntityFrameworkCore;

namespace CapitalCreative.API.Models.Local
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}