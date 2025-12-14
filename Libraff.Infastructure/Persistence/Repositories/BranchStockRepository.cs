using Libraff.Domain;
using Libraff.Domain.Repositories;
using Libraff.Infrastructure.Persistence.Entities;
using Libraff.Infrastructure.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Libraff.Infrastructure.Persistence.Repositories
{
    internal class BranchStockRepository(LibraffDbContext _dbContext) : IBranchStockRepository
    {


        public async Task AddStockItemAsync(BranchStockItem branchStockItem, CancellationToken cancellationToken)
        {
            var (stockEntity, historyEntity) = BranchStockMapper.ToNewBranchStockDeliveryHistoryEntities(branchStockItem);

            await _dbContext.BranchStocks.AddAsync(stockEntity, cancellationToken);
            await _dbContext.BranchDeliveriesHistories.AddAsync(historyEntity,cancellationToken);
        }

        public async Task AddStockItemTransferRequestAsync(TransferableBranchStockItem item, CancellationToken cancellationToken)
        {
            BranchTransferEntity entity = BranchStockMapper.ToNewBranchTransferEntity(item);

            await _dbContext.BranchTransfers.AddAsync(entity, cancellationToken);
        }


        public async Task<TransferableBranchStockItem?> GetStockItemTransferRequestById(int id, CancellationToken cancellationToken)
        {
            BranchTransferEntity? entity = await _dbContext.BranchTransfers
                .Where(t => t.Id == id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity is null)
                return TransferableBranchStockItem.Empty();


            TransferableBranchStockItem result = BranchStockMapper.ToDomainTransferableBranchStockItem(entity);

            return result;

        }

        public void UpdateStockItemTransferRequest(TransferableBranchStockItem transferableBranchStockItem)
        {
            _dbContext.Update(transferableBranchStockItem);
        }

        public async Task MarkConfirmedTransfersAsDelivered()
        {
            await _dbContext.BranchTransfers
                .Where(bt => bt.IsConfirmed == true && bt.IsDelivered == false)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(bt => bt.IsDelivered, true)
                .SetProperty(bt => bt.DeliveryDate, DateTime.Now));

        }


        public async Task<BranchStockItem?> GetStockItemByIdAsync(int id, CancellationToken cancellationToken)
        {
              BranchDeliveriesHistoryEntity? entity = await _dbContext.BranchDeliveriesHistories
                .Include(s => s.BranchStock)
                .Where(s => s.BranchStock.Id == id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity is null)
                return BranchStockItem.Empty();

            BranchStockItem result = BranchStockMapper.ToDomainBranchStockItem(entity);

            return result;

        }




    }
}
