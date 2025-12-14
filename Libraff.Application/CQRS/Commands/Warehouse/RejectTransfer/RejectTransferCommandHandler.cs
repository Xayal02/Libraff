namespace Libraff.Application.CQRS.Commands.Warehouse.RejectTransfer
{
    public class RejectTransferCommandHandler(
        IBranchStockRepository _branchStockRepository,
        IUnitOfWork _unitOfWork) : IRequestHandler<RejectTransferCommand, Result<Unit, Error>>
    {
        public async Task<Result<Unit, Error>> Handle(RejectTransferCommand request, CancellationToken cancellationToken)
        {
            TransferableBranchStockItem? transferableItem = await _branchStockRepository
                .GetStockItemTransferRequestById(request.TransferRequestId, cancellationToken);

            if (transferableItem is null)
                return Result.Failure<Unit, Error>(Error.NotFound());

            transferableItem.RejectTransfer(request.UserId, request.Reason);

            _branchStockRepository.UpdateStockItemTransferRequest(transferableItem);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success<Unit, Error>(Unit.Value);
        }
    }
}
