using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Warehouse
{
    public class BranchTransferConfiguration : IEntityTypeConfiguration<BranchTransferEntity>
    {
        public void Configure(EntityTypeBuilder<BranchTransferEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("branch_transfers_pkey");

            entity.ToTable("branch_transfers", "warehouse");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConfirmDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("confirm_date");
            entity.Property(e => e.ConfirmedCount).HasColumnName("confirmed_count");
            entity.Property(e => e.ConfirmedUserId).HasColumnName("confirmed_user_id");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("delivery_date");
            entity.Property(e => e.FromBranchId).HasColumnName("from_branch_id");
            entity.Property(e => e.IsConfirmed).HasColumnName("is_confirmed");
            entity.Property(e => e.IsDelivered)
                .HasDefaultValue(false)
                .HasColumnName("is_delivered");
            entity.Property(e => e.RejectedUserId).HasColumnName("rejected_user_id");
            entity.Property(e => e.RejectionReason)
                .HasMaxLength(150)
                .HasColumnName("rejection_reason");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("request_date");
            entity.Property(e => e.RequestedCount).HasColumnName("requested_count");
            entity.Property(e => e.RequestedUserId).HasColumnName("requested_user_id");
            entity.Property(e => e.SupplyDetailId).HasColumnName("supply_detail_id");
            entity.Property(e => e.ToBranchId).HasColumnName("to_branch_id");

            entity.HasOne(d => d.SupplyDetail).WithMany(p => p.BranchTransfers)
                .HasForeignKey(d => d.SupplyDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("branch_transfers_supply_detail_id_fkey");
        }
    }
}
