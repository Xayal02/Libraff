namespace Libraff.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee, CancellationToken cancellationToken);
        Task AddEmploymentHistoryAsync(Employee employee, CancellationToken cancellationToken);
        Task UpdatePersonAsync(Employee employee, CancellationToken cancellationToken);
        Task UpdateEmploymentHistoryAsync(Employee employee, CancellationToken cancellationToken);
        Task EndEmploymentAsync(int employeeId, DateTime workEndDate, CancellationToken cancellationToken);
        Task<Employee?> GetByPinAsync(Pin pin, CancellationToken cancellationToken);
        Task<int> GetEmployeeCountByBranchAndPositionAsync(int branchId, int positionId, CancellationToken cancellationToken);
    }
}
