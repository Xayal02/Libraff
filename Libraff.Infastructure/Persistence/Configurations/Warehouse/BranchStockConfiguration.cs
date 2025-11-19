using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Warehouse
{
    public class BranchStockConfiguration : IEntityTypeConfiguration<BranchStockEntity>
    {
        public void Configure(EntityTypeBuilder<BranchStockEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("branch_stock_pk");

            entity.ToTable("branch_stock", "warehouse");

            entity.HasIndex(e => new { e.BranchId, e.SupplyDetailId }, "uq_branch_stock_branch_supply").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.CurrentCount).HasColumnName("current_count");
            entity.Property(e => e.SupplyDetailId).HasColumnName("supply_detail_id");

            entity.HasOne(d => d.SupplyDetail).WithMany(p => p.BranchStocks)
                .HasForeignKey(d => d.SupplyDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_branch_stock_supply_detail");
        }
    }
}
