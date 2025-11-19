namespace Libraff.Infrastructure.Persistence.Entities;

public partial class BonusDetailEntity
{
    public int Id { get; set; }

    public int BonusId { get; set; }

    public int? PositionId { get; set; }

    public decimal SalesMinRange { get; set; }

    public decimal SalesMaxRange { get; set; }

    public decimal Percent { get; set; }

    public virtual BonusEntity Bonus { get; set; } = null!;
}
