using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Persistence.EntityValidator
{
    public class UserValidator : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
