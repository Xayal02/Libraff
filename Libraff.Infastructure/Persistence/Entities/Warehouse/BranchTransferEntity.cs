namespace Libraff.Infrastructure.Persistence.Entities;

public partial class BranchTransferEntity
{
    public int Id { get; set; }

    public int FromBranchId { get; set; }

    public int ToBranchId { get; set; }

    public int SupplyDetailId { get; set; }

    public DateTime RequestDate { get; set; }

    public int RequestedCount { get; set; }

    public int RequestedUserId { get; set; }

    public bool? IsConfirmed { get; set; }

    public DateTime? ConfirmDate { get; set; }

    public int? ConfirmedCount { get; set; }

    public int? ConfirmedUserId { get; set; }

    public bool? IsDelivered { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? RejectionReason { get; set; }

    public int? RejectedUserId { get; set; }

    public virtual SupplyDetailEntity SupplyDetail { get; set; } = null!;
}
