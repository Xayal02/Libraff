using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Warehouse
{
    public class SupplyConfiguration : IEntityTypeConfiguration<SupplyEntity>
    {
        public void Configure(EntityTypeBuilder<SupplyEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("supplies_pk");

            entity.ToTable("supplies", "warehouse");

            entity.HasIndex(e => e.InvoiceNumber, "supplies_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .HasColumnName("invoice_number");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.SupplyDate)
                .HasColumnName("supply_date")
                .HasColumnType("timestamp without time zone");
        }
    }
}
