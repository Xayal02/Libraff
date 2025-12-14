namespace Libraff.Application.CQRS.Commands.Warehouse.ConfirmTransfer
{
    public class ConfirmTransferCommandHandler(
        IBranchStockRepository _branchStockRepository,
        IUnitOfWork _unitOfWork) : IRequestHandler<ConfirmTransferCommand, Result<Unit, Error>>
    {
        public async Task<Result<Unit, Error>> Handle(ConfirmTransferCommand request, CancellationToken cancellationToken)
        {
            TransferableBranchStockItem? transferableItem = await _branchStockRepository
                .GetStockItemTransferRequestById(request.TransferRequestId, cancellationToken);

            if (transferableItem is null)
                return Result.Failure<Unit, Error>(Error.NotFound());

            transferableItem.ConfirmTransfer(request.Count, request.UserId, request.Date);

            _branchStockRepository.UpdateStockItemTransferRequest(transferableItem);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success<Unit, Error>(Unit.Value);
        }
    }
}
