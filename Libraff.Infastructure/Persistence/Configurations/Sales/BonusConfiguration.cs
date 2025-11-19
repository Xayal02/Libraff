using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Sales
{
    public class BonusConfiguration : IEntityTypeConfiguration<BonusEntity>
    {
        public void Configure(EntityTypeBuilder<BonusEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("bonuses_pkey");

            entity.ToTable("bonuses", "sales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplyToAllPositions)
                .HasDefaultValue(false)
                .HasColumnName("apply_to_all_positions");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
        }
    }
}
