using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Persistence.EntityValidator;

namespace CleanArch.Data.Context
{
    public class CleanArchDbContext : DbContext
    {
        public CleanArchDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserValidator());
        }
    }
}
