using Libraff.Domain;
using Libraff.Infrastructure.Persistence.Entities;

namespace Libraff.Infrastructure.Persistence.Mappers
{
    internal class EmployeeMapper
    {
        public static Employee ToDomain(EmploymentHistoryEntity employeeEntity)
        {
            return Employee.Reconstruct(
                Pin.Create(employeeEntity.Person.Pin),
                employeeEntity.Person.FirstName,
                employeeEntity.Person.LastName,
                employeeEntity.Person.Patronymic,
                employeeEntity.Person.DateOfBirth,
                employeeEntity.Person.ResidentialAddress,
                ContactNumber.Create(employeeEntity.Person.ContactNumber),
                employeeEntity.WorkStartDate,
                employeeEntity.BranchId,
                employeeEntity.PositionId,
                employeeEntity.Salary,
                employeeEntity.PersonId,
                employeeEntity.WorkEndDate);


        }

        public static PersonEntity ToNewPersonEntity(Employee employee)
        {
            PersonEntity person = new PersonEntity()
            {
                Pin = employee.Pin.Value,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                DateOfBirth = employee.DateOfBirth,
                ResidentialAddress = employee.ResidentialAddress,
                ContactNumber = employee.ContactNumber.Value
            };

            return person;
        }

        public static (PersonEntity, EmploymentHistoryEntity) ToEntities(Employee employee)
        {
            PersonEntity person = new PersonEntity()
            {
                Pin = employee.Pin.Value,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                DateOfBirth = employee.DateOfBirth,
                ResidentialAddress = employee.ResidentialAddress,
                ContactNumber = employee.ContactNumber.Value
            };

            EmploymentHistoryEntity employment = new EmploymentHistoryEntity()
            {
                Person = person,
                WorkStartDate = employee.WorkStartDate,
                PositionId = employee.PositionId,
                BranchId = employee.BranchId,
                Salary = employee.Salary
            };

            return (person, employment);
        }

        public static void ToUpdatedPersonEntity(PersonEntity personEntity, Employee employee)
        {
            personEntity.FirstName = employee.FirstName;
            personEntity.LastName = employee.LastName;
            personEntity.ResidentialAddress = employee.ResidentialAddress;
            personEntity.ContactNumber = employee.ContactNumber.Value;
        }

        public static EmploymentHistoryEntity ToNewEmploymentHistoryEntity(Employee employee)
        {
            EmploymentHistoryEntity employment = new EmploymentHistoryEntity()
            {
                PersonId = employee.Id,
                WorkStartDate = employee.WorkStartDate,
                PositionId = employee.PositionId,
                BranchId = employee.BranchId,
                Salary = employee.Salary
            };

            return employment;
        }

        public static void ToUpdatedEmploymentHistoryEntity(EmploymentHistoryEntity employmentEntity, Employee employee)
        {
            employmentEntity.BranchId = employee.BranchId;
            employmentEntity.PositionId = employee.PositionId;
            employmentEntity.Salary = employee.Salary;
            employmentEntity.WorkStartDate = employee.WorkStartDate;
        }
    }
}
