namespace Libraff.Application.CQRS.Commands.Organization.TransferEmployee
{
    public class TransferEmployeeCommand : IRequest<Result<Unit,Error>>
    {
        public string EmployeePin { get; set; }
        public int BranchId { get; set; }
        public int? PositionId { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? TransferDate { get; set; }
    }
}
