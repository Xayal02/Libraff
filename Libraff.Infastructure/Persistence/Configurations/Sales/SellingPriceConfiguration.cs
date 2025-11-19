using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Sales
{
    public class SellingPriceConfiguration : IEntityTypeConfiguration<SellingPriceEntity>
    {
        public void Configure(EntityTypeBuilder<SellingPriceEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("selling_prices_pkey");

            entity.ToTable("selling_prices", "sales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.SupplyDetailId).HasColumnName("supply_detail_id");

            entity.HasOne(d => d.SupplyDetail).WithMany(p => p.SellingPrices)
                .HasForeignKey(d => d.SupplyDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("selling_prices_supply_detail_id_fkey");
        }
    }
}
