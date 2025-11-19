using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Warehouse
{
    public class BranchDeliveriesHistoryConfiguration : IEntityTypeConfiguration<BranchDeliveriesHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<BranchDeliveriesHistoryEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("newtable_pk");

            entity.ToTable("branch_deliveries_history", "warehouse");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.DeliveredCount).HasColumnName("delivered_count");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.SupplyDetailId).HasColumnName("supply_detail_id");

            entity.HasOne(d => d.SupplyDetail).WithMany(p => p.BranchDeliveriesHistories)
                .HasForeignKey(d => d.SupplyDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_branch_deliveries_history_supply_detail");
        }
    }
}
