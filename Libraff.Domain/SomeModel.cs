namespace Libraff.Domain
{
    public class GeneralStock
    {
        public int SupplyDetailId { get; set; }
        public int AvailableCount { get; set; }

    }

    public partial class StockEntity2
    {
        public int Id { get; set; }

        public int SupplyDetailId { get; set; }

        public int AvailableCount { get; set; }

    }

    public partial class BranchStock2
    {
        public int Id { get; set; }

        public int BranchId { get; set; }

        public int SupplyDetailId { get; set; }

        public short CurrentCount { get; set; }
    }

    public partial class BranchDeliveriesHistoryEntity2
    {
        public int Id { get; set; }

        public int BranchId { get; set; }

        public int SupplyDetailId { get; set; }

        public short DeliveredCount { get; set; }

        public DateOnly DeliveryDate { get; set; }
    }
    public partial class BranchTransferEntity2
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
    }
}
