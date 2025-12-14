using Libraff.Domain.Constants;
using Libraff.Domain.Exceptions;
using Libraff.Domain.Repositories;

namespace Libraff.Domain.Services
{
    public class EmployeeService(IEmployeeRepository _employeeRepository,
        IPositionLimitRepository _positionLimitRepository)
    {
        public async Task SetEmployeeSalaryAsync(Employee employee, decimal salary, CancellationToken cancellationToken, int? branchId = null, int? positionId = null)
        {

            if (employee is null)
                throw new ArgumentException(DomainErrorMessages.Required(nameof(Employee)));

            if (salary <= 0)
                throw new ArgumentException(DomainErrorMessages.MustBeGreaterThanZero(nameof(employee.Salary)));

            if (!await IsSalaryWithinRangeAsync(
                branchId ?? employee.BranchId, positionId ?? employee.PositionId, 
                salary, cancellationToken))
            {
                throw new ArgumentOutOfRangeException(DomainErrorMessages.SalaryOutOfRange); 
            }

            employee.SetSalary(salary);
        }

        public async Task TransferEmployeeAsync(Employee employee, int branchId, CancellationToken cancellationToken, int? positionId = null, decimal? salary = null, DateTime? transferDate = null)
        {
            if (employee is null)
                throw new ArgumentException(DomainErrorMessages.Required(nameof(Employee)));

            if (branchId <= 0)
                throw new ArgumentException(DomainErrorMessages.MustBeGreaterThanZero(nameof(employee.BranchId)));

            if (salary.HasValue)
            {
                await SetEmployeeSalaryAsync(employee, salary.Value, cancellationToken, branchId, positionId);
            }

            if (await IsEmployeesReachedLimitAsync(branchId, positionId ?? employee.PositionId, cancellationToken))
                throw new ArgumentException(DomainErrorMessages.EmployeeLimitReached); 

            employee.EndWork(transferDate);

            await _employeeRepository.EndEmploymentAsync(employee.Id, employee.WorkEndDate.Value, cancellationToken);

            employee.Transfer(branchId, positionId,salary);

            await _employeeRepository.AddEmploymentHistoryAsync(employee,cancellationToken);


        }

        public async Task<Employee> CreateEmployeeAsync(
            Pin pin,
            string firstName,
            string lastName,
            string patronymic,
            DateOnly? dateOfBirth,
            string residentialAddress,
            ContactNumber contractNumber,
            int branchId,
            int positionId,
            decimal salary,
            CancellationToken cancellationToken,
            DateTime? workStartDate = null
            )
        {
            Employee employee = Employee.Create(pin,firstName, lastName, patronymic,
                dateOfBirth, residentialAddress, contractNumber,
                workStartDate, branchId, positionId, salary);

            if (!await IsSalaryWithinRangeAsync(branchId, positionId, salary, cancellationToken))
                throw new ArgumentOutOfRangeException(DomainErrorMessages.SalaryOutOfRange);

            if (await IsEmployeesReachedLimitAsync(branchId, positionId, cancellationToken))
                throw new ArgumentException(DomainErrorMessages.EmployeeLimitReached); 

            await _employeeRepository.AddAsync(employee, cancellationToken);

            return employee;

        }

        public async Task RehireEmployeeAsync(
            Employee employee,
            string firstName,
            string lastName,
            string residentialAddress,
            ContactNumber contactNumber,
            DateTime? workStartDate,
            int positionId,
            int branchId,
            decimal salary,
            CancellationToken cancellationToken)
        {
            Employee.Rehire(employee, firstName, lastName, residentialAddress, contactNumber, workStartDate, positionId, branchId, salary);

            if (!await IsSalaryWithinRangeAsync(branchId, positionId, salary, cancellationToken))
                throw new ArgumentOutOfRangeException(DomainErrorMessages.SalaryOutOfRange);

            if (await IsEmployeesReachedLimitAsync(branchId, positionId, cancellationToken))
                throw new ArgumentException(DomainErrorMessages.EmployeeLimitReached);

            await _employeeRepository.UpdatePersonAsync(employee,cancellationToken);
            await _employeeRepository.AddEmploymentHistoryAsync(employee,cancellationToken); 

        }

        private async Task<bool> IsSalaryWithinRangeAsync(int branchId, int positionId, decimal salary, CancellationToken cancellationToken)
        {
            SalaryRange? salaryRange = await _positionLimitRepository.GetSalaryRangeAsync(
                branchId, positionId, cancellationToken);

            if (salaryRange is null) throw new NotFoundException(DomainErrorMessages.SalaryRangeNotFound);

            return salary >= salaryRange.MiniumValue && salary <= salaryRange.MaximumValue;

        }

        private async Task<bool> IsEmployeesReachedLimitAsync(int branchId,int positionId, CancellationToken cancellationToken)
        {
            int currentEmployeesCount = await _employeeRepository.GetEmployeeCountByBranchAndPositionAsync(
                branchId,
                positionId,
                cancellationToken);

            int maxEmployeesCount = await _positionLimitRepository.GetMaxAllowedEmployeeCountAsync(
                branchId,
                positionId,
                cancellationToken);

            return currentEmployeesCount  == maxEmployeesCount;
        }

    }
}
