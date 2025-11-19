using Libraff.Domain;
using Libraff.Domain.Repositories;

namespace Libraff.Infrastructure.Persistence.Repositories
{
    public class PositionLimitRepository(LibraffDbContext dbContext) : IPositionLimitRepository
    {
        public async Task<int> GetMaxAllowedEmployeeCountAsync(int branchId, int positionId, CancellationToken cancellationToken)
        {
            int result = await dbContext.BranchPositionLimits
                .Where(l => l.BranchId == branchId &&
                            l.PositionId == positionId)
                .Select(l => l.MaxEmployeesCount)
                .SingleOrDefaultAsync(cancellationToken);

            return result;
        }

        public async Task<SalaryRange?> GetSalaryRangeAsync(int branchId, int positionId, CancellationToken cancellationToken)
        {

            SalaryRange? result = await dbContext.BranchPositionSalaryLimits
                .Where(l => l.BranchId == branchId &&
                            l.PositionId == positionId)
                .Select(l => SalaryRange.Create(l.MinSalary, l.MaxSalary))
                .SingleOrDefaultAsync(cancellationToken);

            return result;

                

        }
    }
}
