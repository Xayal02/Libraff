using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Warehouse
{
    public class BranchDeliveriesHistoryConfiguration : IEntityTypeConfiguration<BranchDeliveriesHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<BranchDeliveriesHistoryEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("newesttable_pk");

            entity.ToTable("branch_deliveries_history", "warehouse");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchStockId).HasColumnName("branch_stock_id");
            entity.Property(e => e.DeliveredCount).HasColumnName("delivered_count");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");

            entity.HasOne(d => d.BranchStock).WithMany(p => p.BranchStockDeliveryHistories)
                .HasForeignKey(d => d.BranchStockId)
                .HasConstraintName("fk_branch_deliveries_history_branch_stock");
        }
    }
}
