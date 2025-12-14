using Libraff.Domain.Constants;
using Libraff.Domain.Exceptions;

namespace Libraff.Domain
{
    public class BranchStockItem
    {
        public int Id { get; }
        public int BranchId { get; }

        public int BookSupplyDetailId { get; }

        public int Count { get; private set; }
        public DateOnly DeliveryDate { get; private set; }

        private BranchStockItem(int id, int branchId, int bookSupplyDetailId, int count, DateOnly? deliveryDate )
        {
            if (branchId <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(BranchId)));

            if (bookSupplyDetailId <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(BookSupplyDetailId)));

            if (count <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(Count)));

            
            BranchId = branchId;
            BookSupplyDetailId = bookSupplyDetailId;
            Count = count;
            DeliveryDate = deliveryDate ?? DateOnly.FromDateTime(DateTime.Now);
        }

        public static BranchStockItem Create(int branchId, int bookSupplyDetailId, int count, DateOnly? deliveryDate)
            => new BranchStockItem(0, branchId, bookSupplyDetailId, count, deliveryDate);

        public static BranchStockItem? Empty()
        {
            return null;
        }

        public static BranchStockItem Reconstruct(int id, int branchId, int bookSupplyDetailId, int count, DateOnly? deliveryDate)
        {
            if (id <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(Id)));

            return new BranchStockItem(id, branchId, bookSupplyDetailId, count, deliveryDate);
        }
    }
}
