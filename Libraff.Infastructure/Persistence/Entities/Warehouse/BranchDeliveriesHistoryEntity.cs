namespace Libraff.Infrastructure.Persistence.Entities;

public partial class BranchDeliveriesHistoryEntity
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public int SupplyDetailId { get; set; }

    public short DeliveredCount { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public virtual SupplyDetailEntity SupplyDetail { get; set; } = null!;
}
