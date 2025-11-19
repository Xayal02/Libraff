namespace Libraff.Infrastructure.Persistence.Entities;

public partial class StockEntity
{
    public int Id { get; set; }

    public int SupplyDetailId { get; set; }

    public int AvailableCount { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public virtual SupplyDetailEntity SupplyDetail { get; set; } = null!;
}
