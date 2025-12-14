namespace Libraff.Infrastructure.Persistence.Entities;

public partial class BranchStockEntity
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public int SupplyDetailId { get; set; }

    public int CurrentCount { get; set; }

    public virtual SupplyDetailEntity SupplyDetail { get; set; } = null!;
    public virtual ICollection<BranchDeliveriesHistoryEntity> BranchStockDeliveryHistories { get; set; } = new List<BranchDeliveriesHistoryEntity>();

}
