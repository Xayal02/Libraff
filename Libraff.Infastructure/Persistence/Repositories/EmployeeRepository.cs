using AutoMapper;
using Libraff.Domain;
using Libraff.Domain.Repositories;
using Libraff.Infrastructure.Persistence.Mappers;

namespace Libraff.Infrastructure.Persistence.Repositories
{
    //I dont like the way I update entites , for updating entities first I get them from db,
    //but since I tried to use Entity Framework I couldnt update the entity models without Id property
    // I could use ExecuteUpdate method, bit it violates the unit of work principle since it SaveChanges automatically
    // Did I created or used domain model incorrectly or I should Use Dapper ?
    internal class EmployeeRepository(LibraffDbContext _dbContext, IMapper _mapper) : IEmployeeRepository
    {

        public async Task AddAsync(Employee employee, CancellationToken cancellationToken)
        {
           var (personEntity, employment) = EmployeeMapper.ToEntities(employee);

            await _dbContext.Persons.AddAsync(personEntity, cancellationToken);

            await _dbContext.EmploymentHistories.AddAsync(employment, cancellationToken);

        }

        public async Task AddEmploymentHistoryAsync(Employee employee, CancellationToken cancellationToken)
        {
            EmploymentHistoryEntity employment = EmployeeMapper.ToNewEmploymentHistoryEntity(employee);

            await _dbContext.EmploymentHistories.AddAsync(employment, cancellationToken);
        }

        public async Task UpdatePersonAsync(Employee employee, CancellationToken cancellationToken)
        {
            PersonEntity personExistingEntity = await GetPersonByIdAsync(employee.Id, cancellationToken);

            EmployeeMapper.ToUpdatedPersonEntity(personExistingEntity, employee);

            _dbContext.Persons.Update(personExistingEntity);
        }

        public async Task UpdateEmploymentHistoryAsync(Employee employee, CancellationToken cancellationToken)
        {
            EmploymentHistoryEntity employmentHistoryEntity = await GetEmploymentByPersonIdAsync(employee.Id, cancellationToken);

            EmployeeMapper.ToUpdatedEmploymentHistoryEntity(employmentHistoryEntity, employee);

            _dbContext.EmploymentHistories.Update(employmentHistoryEntity);
        }

        public async Task EndEmploymentAsync(int employeeId, DateTime workEndDate, CancellationToken cancellationToken)
        {
            EmploymentHistoryEntity employmentHistoryEntity = await GetEmploymentByPersonIdAsync(employeeId, cancellationToken);

            employmentHistoryEntity.WorkEndDate = workEndDate;

            _dbContext.EmploymentHistories.Update(employmentHistoryEntity);

        }

        public async Task<Employee?> GetByPinAsync(Pin pin, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.EmploymentHistories
                .Where(e => e.Person.Pin == pin.Value)
                .Include(e => e.Person)
                .OrderBy(e => e.Id)
                .LastOrDefaultAsync(cancellationToken);

            if (entity is null)
                return Employee.Empty();

            Employee result = EmployeeMapper.ToDomain(entity);

            return result;
        }

        public async Task<int> GetEmployeeCountByBranchAndPositionAsync(int branchId, int positionId, CancellationToken cancellationToken)
        {
            int result = await _dbContext.EmploymentHistories
                .Where(e => e.BranchId == branchId &&
                            e.PositionId == positionId &&
                            e.WorkEndDate == null)
                .CountAsync(cancellationToken);

            return result;
        }

        private async  Task<PersonEntity> GetPersonByIdAsync(int id, CancellationToken cancellationToken)
        {
            PersonEntity result = (await _dbContext.Persons
                .Where(p => p.Id == id)
                .SingleOrDefaultAsync(cancellationToken))!;

            return result;
        }

        private async Task<EmploymentHistoryEntity> GetEmploymentByPersonIdAsync ( int personId, CancellationToken cancellationToken)
        {
            EmploymentHistoryEntity entity = (await _dbContext.EmploymentHistories
                .Where(e => e.PersonId == personId)
                .OrderBy(e => e.Id)
                .LastOrDefaultAsync(cancellationToken))!;

            return entity!;
        }

    }
}
