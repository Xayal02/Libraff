namespace Libraff.Application.CQRS.Commands.Organization.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Result<Unit, Error>>
    {
        public string Pin { get; set; }
        public string? FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Patronymic { get;  set; }
        public DateOnly DateOfBirth { get; set; }
        public string ResidentialAddress { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? WorkStartDate { get; set; }
        public int PositionId { get; set; }
        public int BranchId { get; set; }
        public decimal Salary { get; set; }
    }
}
