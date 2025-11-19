using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Sales
{
    public class DiscountTypeConfiguration : IEntityTypeConfiguration<DiscountTypeEntity>
    {
        public void Configure(EntityTypeBuilder<DiscountTypeEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("discount_types_pk");

            entity.ToTable("discount_types", "sales");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
        }
    }
}
