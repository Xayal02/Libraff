namespace Libraff.Infrastructure.Persistence.Entities;

public partial class BranchPositionLimitEntity
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public int PositionId { get; set; }

    public int MaxEmployeesCount { get; set; }

    public virtual BranchEntity Branch { get; set; } = null!;

    public virtual PositionEntity Position { get; set; } = null!;
}
