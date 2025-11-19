namespace Libraff.Infrastructure.Persistence.Entities;

public partial class BranchStockEntity
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public int SupplyDetailId { get; set; }

    public short CurrentCount { get; set; }

    public virtual SupplyDetailEntity SupplyDetail { get; set; } = null!;
}
