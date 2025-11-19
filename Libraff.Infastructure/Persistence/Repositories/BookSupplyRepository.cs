using Libraff.Domain;
using Libraff.Domain.Repositories;
using Libraff.Infrastructure.Persistence.Mappers;

namespace Libraff.Infrastructure.Persistence.Repositories
{
    public class BookSupplyRepository(LibraffDbContext _dbContext) : IBookSupplyRepository
    {
        public async Task AddSuppliesAsync(BookSupply supply, CancellationToken cancellationToken)
        {
            var (supplyEntity, supplyDetailEntities, stockEntities) = BookSupplyMapper.ToEntities(supply);

            await _dbContext.Supplies.AddAsync(supplyEntity, cancellationToken);

            if (supplyDetailEntities.Count > 0)
                await _dbContext.SupplyDetails.AddRangeAsync(supplyDetailEntities, cancellationToken);

            if(stockEntities.Count > 0)
                await _dbContext.Stocks.AddRangeAsync(stockEntities, cancellationToken);

        }

        public Task AddSuppliesDetailAsync(BookSupplyDetail bookSupplyDetail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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

        public Task UpdateSupplyAsync(BookSupply supply, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
