using Libraff.Application.CQRS.Commands.Warehouse.MakeTransfer;
using Libraff.Domain;
using Libraff.Domain.Repositories;

namespace Libraff.Application.CQRS.Commands.Warehouse.RequestTransfer
{
    public class RequestTransferCommandHandler(
        IBranchStockRepository _branchStockRepository,
        IUnitOfWork _unitOfWork) : IRequestHandler<RequestTransferCommand, Result<Unit, Error>>
    {
        public async Task<Result<Unit, Error>> Handle(RequestTransferCommand request, CancellationToken cancellationToken)
        {
            BranchStockItem? branchStockItem = await _branchStockRepository.GetStockItemByIdAsync(
                request.BranchStockItemId, cancellationToken);

            if (branchStockItem is null)
                return Result.Failure<Unit, Error>(Error.NotFound());

            TransferableBranchStockItem transferableBranchStockItem = TransferableBranchStockItem.Create(
                branchStockItem, request.ToBranchId, request.Date, request.Count, request.UserId);

            if (request.Count > branchStockItem.Count)
                return Result.Failure<Unit, Error>(Error.Conflict());

            await _branchStockRepository.AddStockItemTransferRequestAsync(transferableBranchStockItem, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success<Unit, Error>(Unit.Value);
        }
    }
}
