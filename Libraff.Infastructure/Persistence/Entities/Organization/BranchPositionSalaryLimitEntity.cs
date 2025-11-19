namespace Libraff.Infrastructure.Persistence.Entities;

public partial class BranchPositionSalaryLimitEntity
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public int PositionId { get; set; }

    public decimal MinSalary { get; set; }

    public decimal MaxSalary { get; set; }

    public virtual BranchEntity Branch { get; set; } = null!;

    public virtual PositionEntity Position { get; set; } = null!;
}
