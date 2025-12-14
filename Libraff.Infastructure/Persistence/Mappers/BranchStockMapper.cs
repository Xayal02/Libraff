using Libraff.Domain;

namespace Libraff.Infrastructure.Persistence.Mappers
{
    public static class BranchStockMapper
    {
        public static (BranchStockEntity, BranchDeliveriesHistoryEntity) ToNewBranchStockDeliveryHistoryEntities(BranchStockItem item)
        {
            BranchStockEntity stockEntity = new BranchStockEntity()
            {
                BranchId = item.BranchId,
                SupplyDetailId = item.BookSupplyDetailId,
                CurrentCount = item.Count
            };

            BranchDeliveriesHistoryEntity historyEntity = new BranchDeliveriesHistoryEntity()
            {
                DeliveredCount = item.Count,
                DeliveryDate = item.DeliveryDate,
                BranchStock = stockEntity
            };

            return (stockEntity, historyEntity);

        }
        public static BranchTransferEntity ToNewBranchTransferEntity(TransferableBranchStockItem item)
        {
            BranchTransferEntity entity = new BranchTransferEntity()
            {
                FromBranchId = item.TransferableStockItem.BranchId,
                ToBranchId = item.ToBranchId,
                SupplyDetailId = item.TransferableStockItem.BookSupplyDetailId,
                RequestDate = item.RequestDate,
                RequestedCount = item.RequestedCount,
                RequestedUserId = item.RequestedUserId,
            };

            return entity;
        }

        public static TransferableBranchStockItem ToDomainTransferableBranchStockItem(BranchTransferEntity entity)
        {
            TransferableBranchStockItem domainModel = TransferableBranchStockItem.Reconstruct(
                entity.Id,
                BranchStockItem.Create(
                    entity.FromBranchId, entity.SupplyDetailId, entity.RequestedCount, null),
                entity.ToBranchId,
                entity.RequestDate,
                entity.RequestedCount,
                entity.RequestedUserId,
                entity.IsConfirmed

                );

            return domainModel;
        }

        public static BranchStockItem ToDomainBranchStockItem(BranchDeliveriesHistoryEntity entity)
        {
            BranchStockItem domainModel = BranchStockItem.Reconstruct(
                entity.BranchStock.Id,
                entity.BranchStock.BranchId,
                entity.BranchStock.SupplyDetailId, 
                entity.BranchStock.CurrentCount, 
                entity.DeliveryDate);

            return domainModel;
        }
    }
}
