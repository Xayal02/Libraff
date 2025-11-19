using Libraff.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations
{
    public class EmploymentHistoryConfiguration : IEntityTypeConfiguration<EmploymentHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<EmploymentHistoryEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("employment_history_pkey");

            entity.ToTable("employment_history", "organization");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.Salary)
                .HasPrecision(12, 2)
                .HasColumnName("salary");
            entity.Property(e => e.WorkEndDate).HasColumnName("work_end_date");
            entity.Property(e => e.WorkStartDate).HasColumnName("work_start_date");

            entity.HasOne(d => d.Branch).WithMany(p => p.EmploymentHistories)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employment_history_branch_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.EmploymentHistories)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("employment_history_person_id_fkey");

            entity.HasOne(d => d.Position).WithMany(p => p.EmploymentHistories)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employment_history_position_id_fkey");
        }
    }
}
