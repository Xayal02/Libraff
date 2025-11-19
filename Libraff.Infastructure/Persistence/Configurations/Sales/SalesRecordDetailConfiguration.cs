using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Sales
{
    public class SalesRecordDetailConfiguration : IEntityTypeConfiguration<SalesRecordDetailEntity>
    {
        public void Configure(EntityTypeBuilder<SalesRecordDetailEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("sales_record_details_pkey");

            entity.ToTable("sales_record_details", "sales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FixedPrice)
                .HasPrecision(10, 2)
                .HasColumnName("fixed_price");
            entity.Property(e => e.PriceAfterDiscount)
                .HasPrecision(10, 2)
                .HasColumnName("price_after_discount");
            entity.Property(e => e.Quantity)
                .HasDefaultValue((short)1)
                .HasColumnName("quantity");
            entity.Property(e => e.SalesRecordId).HasColumnName("sales_record_id");
            entity.Property(e => e.SupplyDetailId).HasColumnName("supply_detail_id");

            entity.HasOne(d => d.SalesRecord).WithMany(p => p.SalesRecordDetails)
                .HasForeignKey(d => d.SalesRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sales_record_details_sales_record_id_fkey");

            entity.HasOne(d => d.SupplyDetail).WithMany(p => p.SalesRecordDetails)
                .HasForeignKey(d => d.SupplyDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sales_record_details_supply_detail_id_fkey");
        }
    }
}
