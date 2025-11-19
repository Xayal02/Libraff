using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Sales
{
    public class DiscountConfiguration : IEntityTypeConfiguration<DiscountEntity>
    {
        public void Configure(EntityTypeBuilder<DiscountEntity> entity)
        {
            entity.ToTable("discounts_v1", "sales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiscountTypeId).HasColumnName("discount_type_id");
            entity.Property(e => e.Percent)
                .HasPrecision(2, 1)
                .HasColumnName("percent");
            entity.Property(e => e.ReferenceId).HasColumnName("reference_id");
            entity.Property(e => e.ValidFrom)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("valid_from");
            entity.Property(e => e.ValidTo)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("valid_to");
        }
    }
}
