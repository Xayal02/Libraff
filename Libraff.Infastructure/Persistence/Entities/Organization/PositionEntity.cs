namespace Libraff.Infrastructure.Persistence.Entities;

public partial class PositionEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public short Order { get; set; }

    public virtual ICollection<BranchPositionLimitEntity> BranchPositionLimits { get; set; } = new List<BranchPositionLimitEntity>();

    public virtual ICollection<BranchPositionSalaryLimitEntity> BranchPositionSalaryLimits { get; set; } = new List<BranchPositionSalaryLimitEntity>();

    public virtual ICollection<EmploymentHistoryEntity> EmploymentHistories { get; set; } = new List<EmploymentHistoryEntity>();
}
