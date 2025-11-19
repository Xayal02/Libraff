using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Warehouse
{
    public class SupplyDetailConfiguration : IEntityTypeConfiguration<SupplyDetailEntity>
    {
        public void Configure(EntityTypeBuilder<SupplyDetailEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("supply_details_pk");

            entity.ToTable("supply_details", "warehouse");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.InitialCount).HasColumnName("initial_count");
            entity.Property(e => e.PricePerBook)
                .HasPrecision(10, 2)
                .HasColumnName("price_per_book");
            entity.Property(e => e.SupplyId).HasColumnName("supply_id");

            entity.HasOne(d => d.Supply).WithMany(p => p.SupplyDetails)
                .HasForeignKey(d => d.SupplyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_supply_details_supply");
        }
    }
}
