using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Warehouse
{
    public class StockConfiguration : IEntityTypeConfiguration<StockEntity>
    {
        public void Configure(EntityTypeBuilder<StockEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("stock_pk");

            entity.ToTable("stock", "warehouse");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvailableCount).HasColumnName("available_count");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modified_at");
            entity.Property(e => e.SupplyDetailId).HasColumnName("supply_detail_id");

            entity.HasOne(d => d.SupplyDetail).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.SupplyDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_stock_supply_detail");
        }
    }
}
