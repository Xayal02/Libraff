using Libraff.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Organization
{
    public class BranchPositionLimitConfiguration : IEntityTypeConfiguration<BranchPositionLimitEntity>
    {
        public void Configure(EntityTypeBuilder<BranchPositionLimitEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("branch_position_limits_pkey");

            entity.ToTable("branch_position_limits", "organization");

            entity.HasIndex(e => new { e.BranchId, e.PositionId }, "branch_position_limits_branch_id_position_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.MaxEmployeesCount).HasColumnName("max_employees_count");
            entity.Property(e => e.PositionId).HasColumnName("position_id");

            entity.HasOne(d => d.Branch).WithMany(p => p.BranchPositionLimits)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("branch_position_limits_branch_id_fkey");

            entity.HasOne(d => d.Position).WithMany(p => p.BranchPositionLimits)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("branch_position_limits_position_id_fkey");
        }
    }
}
