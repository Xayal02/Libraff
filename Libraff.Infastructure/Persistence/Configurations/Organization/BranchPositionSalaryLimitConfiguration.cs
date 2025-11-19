using Libraff.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations
{
    public class BranchPositionSalaryLimitConfiguration : IEntityTypeConfiguration<BranchPositionSalaryLimitEntity>
    {
        public void Configure(EntityTypeBuilder<BranchPositionSalaryLimitEntity> entity)
        {
			entity.HasKey(e => e.Id).HasName("branch_position_salary_limits_pkey");

			entity.ToTable("branch_position_salary_limits", "organization");

			entity.HasIndex(e => new { e.BranchId, e.PositionId }, "branch_position_salary_limits_branch_id_position_id_key").IsUnique();

			entity.Property(e => e.Id).HasColumnName("id");
			entity.Property(e => e.BranchId).HasColumnName("branch_id");
			entity.Property(e => e.MaxSalary)
				.HasPrecision(10, 2)
				.HasColumnName("max_salary");
			entity.Property(e => e.MinSalary)
				.HasPrecision(10, 2)
				.HasColumnName("min_salary");
			entity.Property(e => e.PositionId).HasColumnName("position_id");

			entity.HasOne(d => d.Branch).WithMany(p => p.BranchPositionSalaryLimits)
				.HasForeignKey(d => d.BranchId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("branch_position_salary_limits_branch_id_fkey");

			entity.HasOne(d => d.Position).WithMany(p => p.BranchPositionSalaryLimits)
				.HasForeignKey(d => d.PositionId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("branch_position_salary_limits_position_id_fkey");
		}
    }
}
