using Libraff.Domain.Constants;
using Libraff.Domain.Exceptions;

namespace Libraff.Domain
{
    public class TransferableBranchStockItem
    {
        public int Id { get; }
        public BranchStockItem TransferableStockItem { get; }
        public int ToBranchId { get; }
        public int RequestedCount { get; }
        public DateTime RequestDate { get; }
        public int RequestedUserId { get; }
        public bool? IsConfirmed { get; private set; }
        public int? ConfirmedCount { get; private set; }
        public DateTime? ConfirmDate { get; private set; }
        public int? ConfirmedUserId { get; private set; }
        public string? RejectionReason { get; private set; }
        public int? RejectedUserId { get; private set; }
        //public bool? IsDelivered { get; set; }
        //public DateTime? DeliveryDate { get; set; }

        private TransferableBranchStockItem(
            int id, BranchStockItem branchStockItem, int toBranchId,
            int requestedCount, DateTime? requestDate, int userId, bool? isConfirmed = null)
        {

            if (toBranchId <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(toBranchId)));

            if (requestedCount <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(RequestedCount)));

            if (userId <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(userId)));

            Id = id;
            TransferableStockItem = branchStockItem;
            ToBranchId = toBranchId;
            RequestDate = requestDate ?? DateTime.Now;
            RequestedCount = requestedCount;
            RequestedUserId = userId;
            IsConfirmed = isConfirmed;
        }

        public static TransferableBranchStockItem Create(
            BranchStockItem branchStockItem, int toBranchId,
            DateTime? requestDate, int requestedCount, int userId)
        {
            return new TransferableBranchStockItem(0, branchStockItem, toBranchId, requestedCount, requestDate, userId);
        }

        public static TransferableBranchStockItem Reconstruct(
            int id, BranchStockItem branchStockItem, int toBranchId,
            DateTime? requestDate, int requestedCount, int requestedUserId, bool? isConfirmed)
        {
            if (id <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(Id)));


            return new TransferableBranchStockItem(id, branchStockItem, toBranchId, requestedCount, requestDate, requestedUserId, isConfirmed);
        }

        public static TransferableBranchStockItem? Empty()
        {
            return null;
        }

        public void ConfirmTransfer(int count, int userId, DateTime? date)
        {
            if (count <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(ConfirmedCount)));

            if (userId <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(ConfirmedUserId)));

            if (IsConfirmed is not null)
                throw new ValidationException(DomainErrorMessages.TransferRequestAlreadyProcessed);

            IsConfirmed = true;
            ConfirmedCount = count;
            ConfirmedUserId = userId;
            ConfirmDate = date ?? DateTime.Now;
        }

        public void RejectTransfer(int userId, string reason)
        {
            if (userId <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(RejectedUserId)));

            if (string.IsNullOrEmpty(reason))
                throw new ValidationException(DomainErrorMessages.Required(nameof(RejectionReason)));

            if (IsConfirmed is not null)
                throw new ValidationException(DomainErrorMessages.TransferRequestAlreadyProcessed);

            IsConfirmed = false;
            RejectedUserId = userId;
            RejectionReason = reason;
        }




    }
}
