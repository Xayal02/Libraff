namespace Libraff.Domain.Repositories
{
    public interface IPositionLimitRepository
    {
        Task<SalaryRange?> GetSalaryRangeAsync(int branchId, int positionId,CancellationToken cancellationToken);
        Task<int> GetMaxAllowedEmployeeCountAsync(int branchId, int positionId, CancellationToken cancellationToken);
        
    }
}
