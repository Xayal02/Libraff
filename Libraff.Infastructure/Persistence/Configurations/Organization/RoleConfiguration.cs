using Libraff.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Organization
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("roles_pk");

            entity.ToTable("roles", "organization");

            entity.HasIndex(e => e.Name, "roles_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        }
    }
}
