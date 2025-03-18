using Microsoft.EntityFrameworkCore;
using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Persistence.Context
{
    public class PublishingHouseManagementContext : DbContext
    {
        public PublishingHouseManagementContext(DbContextOptions<PublishingHouseManagementContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PublishingHouseManagementContext).Assembly);
        }
    }
}