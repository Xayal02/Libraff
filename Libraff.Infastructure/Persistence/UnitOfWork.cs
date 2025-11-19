using Libraff.Application.Abstractions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Libraff.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly LibraffDbContext _dbContext;
        IDbContextTransaction? _transaction;

        public UnitOfWork(LibraffDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            if (_transaction is not null)
            {
                await _transaction.CommitAsync(cancellationToken);
                await _transaction.DisposeAsync();
                _transaction = null;

            }
        }

        public async Task RollBackAsync(CancellationToken cancellationToken)
        {
            if (_transaction is not null)
            {
                await _transaction.RollbackAsync(cancellationToken);
                await _transaction.DisposeAsync();
                _transaction = null;

            }
        }

    }
}
