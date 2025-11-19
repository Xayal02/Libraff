using Libraff.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Organization
{
    public class BranchConfiguration : IEntityTypeConfiguration<BranchEntity>
    {
        public void Configure(EntityTypeBuilder<BranchEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("branches_pkey");

            entity.ToTable("branches", "organization");

            entity.HasIndex(e => e.Code, "branches_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(20)
                .HasColumnName("contact_number");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        }
    }
}
