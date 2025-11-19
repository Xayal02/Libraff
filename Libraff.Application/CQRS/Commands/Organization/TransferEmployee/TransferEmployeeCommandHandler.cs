namespace Libraff.Application.CQRS.Commands.Organization.TransferEmployee
{
    public class TransferEmployeeCommandHandler : IRequestHandler<TransferEmployeeCommand, Result<Unit, Error>>
    {
        private readonly EmployeeService _employeeService;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TransferEmployeeCommandHandler(EmployeeService employeeService, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Unit, Error>> Handle(TransferEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee? employee = await _employeeRepository.GetByPinAsync(Pin.Create(request.EmployeePin), cancellationToken);

            if (employee is null)
                return Result.Failure<Unit, Error>(Error.NotFound());

            await _employeeService.TransferEmployeeAsync(
                employee, request.BranchId, cancellationToken, 
                request.PositionId, request.Salary, request.TransferDate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success<Unit, Error>(Unit.Value);
        }
    }
}
