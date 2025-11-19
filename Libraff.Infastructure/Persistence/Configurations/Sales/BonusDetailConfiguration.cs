using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Sales
{
    public class BonusDetailConfiguration : IEntityTypeConfiguration<BonusDetailEntity>
    {
        public void Configure(EntityTypeBuilder<BonusDetailEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("bonus_details_pkey");

            entity.ToTable("bonus_details", "sales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BonusId).HasColumnName("bonus_id");
            entity.Property(e => e.Percent)
                .HasPrecision(5, 2)
                .HasColumnName("percent");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.SalesMaxRange)
                .HasPrecision(10, 2)
                .HasColumnName("sales_max_range");
            entity.Property(e => e.SalesMinRange)
                .HasPrecision(10, 2)
                .HasColumnName("sales_min_range");

            entity.HasOne(d => d.Bonus).WithMany(p => p.BonusDetails)
                .HasForeignKey(d => d.BonusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bonus_details_bonus_id_fkey");
        }
    }
}
