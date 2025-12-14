using Libraff.Domain.Constants;
using System.Runtime.CompilerServices;
using Libraff.Domain.Exceptions;

[assembly: InternalsVisibleTo("Libraff.Infrastructure")]

namespace Libraff.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public Pin Pin { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Patronymic { get; set; }
        public DateOnly DateOfBirth { get;  set; }
        public string ResidentialAddress { get; private set; }
        public ContactNumber ContactNumber { get; private set; }
        public DateTime WorkStartDate { get; set; }
        public DateTime? WorkEndDate { get; private set; }
        public int PositionId { get; private set; }
        public int BranchId { get; private set; }
        public decimal Salary { get; private set; }

        internal void SetSalary(decimal salary)
        {
            Salary = salary;
        }

        internal void Transfer(int branchId, int? positionId = null, decimal? salary = null)
        {
            BranchId = branchId;
            PositionId = positionId ?? PositionId;
            Salary = salary ?? Salary;
            WorkEndDate = null;
        }

        internal static void Rehire(
            Employee employee,
            string firstName,
            string lastName,
            string residentialAddress,
            ContactNumber contactNumber,
            DateTime? workStartDate,
            int positionId,
            int branchId,
            decimal salary)
        {
            if (employee is null)
                throw new ValidationException(DomainErrorMessages.Required(nameof(Employee)));

            if (string.IsNullOrEmpty(firstName))
                throw new ValidationException(DomainErrorMessages.Required(nameof(FirstName)));

            if (string.IsNullOrEmpty(lastName))
                throw new ValidationException(DomainErrorMessages.Required(nameof(LastName)));

            if (string.IsNullOrEmpty(residentialAddress))
                throw new ValidationException(DomainErrorMessages.Required(nameof(ResidentialAddress)));

            if (branchId <= 0)
                throw new ValidationException(DomainErrorMessages.MustBeGreaterThanZero(nameof(BranchId)));

            if (positionId <= 0)
                throw new ValidationException(DomainErrorMessages.MustBeGreaterThanZero(nameof(PositionId)));

            if (salary <= 0)
                throw new ValidationException(DomainErrorMessages.MustBeGreaterThanZero(nameof(Salary)));

            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.ResidentialAddress = residentialAddress;
            employee.ContactNumber = contactNumber;
            employee.WorkStartDate = workStartDate ?? DateTime.Now;
            employee.WorkEndDate = null;
            employee.PositionId = positionId;
            employee.BranchId = branchId;
            employee.Salary = salary;
        }

        public void EndWork(DateTime? workEndDate)
        {
            WorkEndDate = workEndDate ?? DateTime.Now;
        }


        private Employee(
            Pin pin,
            string firstName,
            string lastName,
            string patronymic,
            DateOnly dateOfBirth,
            string residentialAddress,
            ContactNumber contractNumber,
            DateTime? workStartDate,
            int branchId,
            int positionId,
            decimal salary,
            int id = 0,
            DateTime? workEndDate = null)
        {
            Pin = pin;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            ResidentialAddress = residentialAddress;
            ContactNumber = contractNumber;
            WorkStartDate = workStartDate ?? DateTime.Now;
            PositionId = positionId;
            BranchId = branchId;
            Salary = salary;
            if (id > 0)
                Id = id;
            WorkEndDate = workEndDate;
        }

        internal static Employee Create(
            Pin pin,
            string firstName,
            string lastName,
            string patronymic,
            DateOnly? dateOfBirth,
            string residentialAddress,
            ContactNumber contractNumber,
            DateTime? workStartDate,
            int branchId,
            int positionId,
            decimal salary)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ValidationException(DomainErrorMessages.Required(nameof(FirstName))); 

            if (string.IsNullOrEmpty(lastName))
                throw new ValidationException(DomainErrorMessages.Required(nameof(LastName))); 

            if (string.IsNullOrEmpty(patronymic))
                throw new ValidationException(DomainErrorMessages.Required(nameof(Patronymic)));

            if (!dateOfBirth.HasValue)
                throw new ValidationException(DomainErrorMessages.Required(nameof(DateOfBirth)));

            if (DateTime.Now.Year - dateOfBirth.Value.Year < DomainConstraints.ElligibleWorkAge)
                throw new ValidationException(DomainErrorMessages.UnderEligibleWorkingAge);

            if (string.IsNullOrEmpty(residentialAddress))
                throw new ValidationException(DomainErrorMessages.Required(nameof(ResidentialAddress)));

            if (branchId <= 0)
                throw new ValidationException(DomainErrorMessages.MustBeGreaterThanZero(nameof(BranchId)));

            if (positionId <= 0)
                throw new ValidationException(DomainErrorMessages.MustBeGreaterThanZero(nameof(PositionId)));

            if (salary <= 0)
                throw new ValidationException(DomainErrorMessages.MustBeGreaterThanZero(nameof(Salary)));


            return new Employee
                (pin ,firstName, lastName, patronymic,
                dateOfBirth.Value, residentialAddress, contractNumber,
                workStartDate, positionId, branchId, salary);
        }

        internal static Employee Reconstruct(
            Pin pin,
            string firstName,
            string lastName,
            string patronymic,
            DateOnly? dateOfBirth,
            string residentialAddress,
            ContactNumber contractNumber,
            DateTime? workStartDate,
            int branchId,
            int positionId,
            decimal salary,
            int id,
            DateTime? workEndDate)
        {
            return new Employee
                (pin, firstName, lastName, patronymic,
                dateOfBirth.Value, residentialAddress, contractNumber,
                workStartDate, positionId, branchId, salary, id,workEndDate);

        }

        public static Employee? Empty()
        {
            return null;
        }
    }




}
