namespace Libraff.Infrastructure.Persistence.Entities;

public partial class EmploymentHistoryEntity
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public DateTime WorkStartDate { get; set; }

    public DateTime? WorkEndDate { get; set; }

    public int PositionId { get; set; }

    public int BranchId { get; set; }

    public decimal Salary { get; set; }

    public virtual BranchEntity Branch { get; set; } = null!;

    public virtual PersonEntity Person { get; set; } = null!;

    public virtual PositionEntity Position { get; set; } = null!;
}
