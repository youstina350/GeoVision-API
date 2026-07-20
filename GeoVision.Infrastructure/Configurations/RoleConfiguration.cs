using GeoVision.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoVision.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasMaxLength(50)
               .IsRequired();

        builder.HasData(
            new Role
            {
                Id = 1,
                Name = "Admin",
                CreatedAt = DateTime.UtcNow
            },
            new Role
            {
                Id = 2,
                Name = "User",
                CreatedAt = DateTime.UtcNow
            });
    }
}