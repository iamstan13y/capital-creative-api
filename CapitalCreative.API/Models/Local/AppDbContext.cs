using CapitalCreative.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CapitalCreative.API.Models.Local
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Quote> Quotes { get; set; }
    }
}