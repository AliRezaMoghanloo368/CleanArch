using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Data.Context
{
    public class CleanArchDbContext : DbContext
    {
        public CleanArchDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfiguration(new CategoryValidator());
        //    modelBuilder.ApplyConfiguration(new ProductValidator());
        //    modelBuilder.ApplyConfiguration(new UserValidator());
        //    modelBuilder.ApplyConfiguration(new ShoppingCartValidator());
        //    modelBuilder.ApplyConfiguration(new CartItemValidator());
        //}
    }
}
