using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libraff.Infrastructure.Persistence.Configurations.Sales
{
    public class SalesRecordConfiguration : IEntityTypeConfiguration<SalesRecordEntity>
    {
        public void Configure(EntityTypeBuilder<SalesRecordEntity> entity)
        {
            entity.HasKey(e => e.Id).HasName("sales_records_pkey");

            entity.ToTable("sales_records", "sales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.SaleDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sale_date");
        }
    }
}
