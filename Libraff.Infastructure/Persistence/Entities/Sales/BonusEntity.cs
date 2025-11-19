namespace Libraff.Infrastructure.Persistence.Entities;

public partial class BonusEntity
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public bool? ApplyToAllPositions { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<BonusDetailEntity> BonusDetails { get; set; } = new List<BonusDetailEntity>();
}
