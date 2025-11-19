namespace Libraff.Infrastructure.Persistence.Entities;

public partial class BranchEntity
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Location { get; set; } = null!;

    public string? ContactNumber { get; set; }

    public virtual ICollection<BranchPositionLimitEntity> BranchPositionLimits { get; set; } = new List<BranchPositionLimitEntity>();

    public virtual ICollection<BranchPositionSalaryLimitEntity> BranchPositionSalaryLimits { get; set; } = new List<BranchPositionSalaryLimitEntity>();

    public virtual ICollection<EmploymentHistoryEntity> EmploymentHistories { get; set; } = new List<EmploymentHistoryEntity>();
}
