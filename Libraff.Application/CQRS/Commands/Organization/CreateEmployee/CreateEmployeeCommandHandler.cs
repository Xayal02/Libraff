namespace Libraff.Application.CQRS.Commands.Organization.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<Unit, Error>>
    {
        readonly EmployeeService _employeeService;
        readonly IEmployeeRepository _employeeRepository;
        readonly IUnitOfWork _unitOfWork;

        public CreateEmployeeCommandHandler(
            EmployeeService employeeService,
            IEmployeeRepository employeeRepository,
            IUnitOfWork unitOfWork)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Unit, Error>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee? existingEmployee = await _employeeRepository.GetByPinAsync(Pin.Create(request.Pin), cancellationToken);

            if(existingEmployee is null)
            {
                Employee newEmployee = await _employeeService.CreateEmployeeAsync(
                    Pin.Create(request.Pin),
                    request.FirstName,request.LastName,request.Patronymic,
                    request.DateOfBirth,request.ResidentialAddress,ContactNumber.Create(request.ContactNumber),
                    request.BranchId,request.PositionId,request.Salary,cancellationToken);

            }
            else
            {
                if (existingEmployee.WorkEndDate is null)
                    return Result.Failure<Unit, Error>(Error.Conflict());

                await _employeeService.RehireEmployeeAsync(existingEmployee, 
                    request.FirstName, request.LastName, request.ResidentialAddress, 
                    ContactNumber.Create(request.ContactNumber), request.WorkStartDate, 
                    request.PositionId, request.BranchId, request.Salary, cancellationToken);

            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success<Unit, Error>(Unit.Value);

        }
    }
}
