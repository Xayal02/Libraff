using Libraff.Domain;
using Libraff.Domain.Repositories;
using Libraff.Infrastructure.Persistence.Mappers;
using System.Threading;

namespace Libraff.Infrastructure.Persistence.Repositories
{

    //I dont like the way I update entites , for updating entities first I get them from db,
    //but since I tried to use Entity Framework I couldnt update the entity models without Id property
    // I could use ExecuteUpdate method, bit it violates the unit of work principle since it SaveChanges automatically
    // Did I created or used domain model incorrectly or I should Use Dapper ?
    internal class BookSupplyRepository(LibraffDbContext _dbContext) : IBookSupplyRepository
    {
        public async Task AddSuppliesAsync(BookSupply supply, CancellationToken cancellationToken)
        {
            var (supplyEntity, supplyDetailEntities, stockEntities) = BookSupplyMapper.ToNewEntities(supply);

            await _dbContext.Supplies.AddAsync(supplyEntity, cancellationToken);

            if (supplyDetailEntities.Count > 0)
                await _dbContext.SupplyDetails.AddRangeAsync(supplyDetailEntities, cancellationToken);

            if(stockEntities.Count > 0)
                await _dbContext.Stocks.AddRangeAsync(stockEntities, cancellationToken);

        }

        public async Task AddSupplyDetailAsync(BookSupplyDetail bookSupplyDetail, int supplyId, CancellationToken cancellationToken)
        {
            var (supplyDetailEntity, stockEntity) = BookSupplyMapper.ToNewSupplyDetailAndStockEntities(supplyId, bookSupplyDetail);

            await _dbContext.SupplyDetails.AddAsync(supplyDetailEntity, cancellationToken);

            await _dbContext.Stocks.AddAsync(stockEntity, cancellationToken);
        }

        public async Task<BookSupplyDetail?> GetBookSupplyDetailAsync(int supplierId, int bookId, CancellationToken cancellationToken)
        {
            SupplyDetailEntity? entity = await _dbContext.SupplyDetails
                .Where(s => s.SupplyId == supplierId &&
                            s.BookId == bookId)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                return BookSupplyDetail.Empty();

            BookSupplyDetail result = BookSupplyDetail.Create(
                entity.BookId, entity.PricePerBook, entity.InitialCount);

            return result;
        }

        public Task<BookSupply> GetSupplyByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsExist(InvoiceNumber invoiceNumber, CancellationToken cancellationToken)
        {
            SupplyEntity? supply = await _dbContext.Supplies
                .Where(s => s.InvoiceNumber == invoiceNumber.Value)
                .SingleOrDefaultAsync(cancellationToken);

            return supply != null;
        }

        public async Task RemoveSupplyDetailAsync(int supplyId, BookSupplyDetail bookSupplyDetail, CancellationToken cancellationToken)
        {
            SupplyDetailEntity supplyDetailEntity = await GetSupplyDetailEntity(
                supplyId, bookSupplyDetail.BookId, cancellationToken);

            StockEntity stockEntity = await GetStockEntity(supplyDetailEntity.Id, cancellationToken);

            _dbContext.SupplyDetails.Remove(supplyDetailEntity);

            _dbContext.Stocks.Remove(stockEntity);

        }

        private async Task<SupplyDetailEntity> GetSupplyDetailEntity(int supplyId, int bookId, CancellationToken cancellationToken)
        {
            SupplyDetailEntity supplyDetailEntity = (await _dbContext.SupplyDetails
                .Where(s => s.SupplyId ==  supplyId &&
                            s.BookId == bookId)
                .SingleOrDefaultAsync(cancellationToken))!;

            return supplyDetailEntity;
        }

        private async Task<StockEntity> GetStockEntity(int supplyDetailId, CancellationToken cancellationToken)
        {
            StockEntity stockEntity = (await _dbContext.Stocks
                .Where(s => s.SupplyDetailId  == supplyDetailId)
                .SingleOrDefaultAsync(cancellationToken))!;

            return stockEntity;
        }

        public async Task UpdateSupplyDetailAsync(int supplyId, BookSupplyDetail bookSupplyDetail, CancellationToken cancellationToken)
        {
            SupplyDetailEntity supplyDetailEntity = await GetSupplyDetailEntity(
                supplyId, bookSupplyDetail.BookId, cancellationToken);

            StockEntity stockEntity = await GetStockEntity(
                supplyDetailEntity.Id, cancellationToken);

            BookSupplyMapper.ToUpdatedSupplyDetailAndStockEntities(
                bookSupplyDetail, supplyDetailEntity, stockEntity);

            _dbContext.SupplyDetails.Update(supplyDetailEntity);

            _dbContext.Stocks.Update(stockEntity);
        }




        public async Task UpdateSupplyDetailCountAsync(int supplyId, BookSupplyDetail bookSupplyDetail, int count, CancellationToken cancellationToken)
        {
            SupplyDetailEntity supplyDetailEntity = await GetSupplyDetailEntity(
                supplyId, bookSupplyDetail.BookId, cancellationToken);

            StockEntity stockEntity = await GetStockEntity(
                supplyDetailEntity.Id, cancellationToken);

            supplyDetailEntity.InitialCount += count;

            stockEntity.AvailableCount += count;

            _dbContext.SupplyDetails.Update(supplyDetailEntity);

            _dbContext.Stocks.Update(stockEntity);
        }

        public async Task<int> GetSupplyDetailCountAsync(int supplyDetailId, CancellationToken cancellationToken)
        {
           int availableCount =  await _dbContext.Stocks
                .Where(s => s.SupplyDetailId == supplyDetailId)
                .Select(s => s.AvailableCount)
                .SingleOrDefaultAsync(cancellationToken);

            return availableCount;
        }
    }
}
