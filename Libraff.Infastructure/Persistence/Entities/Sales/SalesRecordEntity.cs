namespace Libraff.Infrastructure.Persistence.Entities;

public partial class SalesRecordEntity
{
    public int Id { get; set; }

    public DateTime SaleDate { get; set; }

    public int EmployeeId { get; set; }

    public int BranchId { get; set; }

    public virtual ICollection<SalesRecordDetailEntity> SalesRecordDetails { get; set; } = new List<SalesRecordDetailEntity>();
}
