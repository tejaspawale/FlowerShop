using Microsoft.EntityFrameworkCore;
using MyAssessment.WebMVC.Models;

namespace MyAssessment.WebMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Home> Homes { get; set; }

        public DbSet<HomeProduct> HomeProducts { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

    }
}
