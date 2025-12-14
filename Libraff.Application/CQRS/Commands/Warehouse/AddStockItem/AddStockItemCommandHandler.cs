namespace Libraff.Application.CQRS.Commands.Warehouse.AddStockItem
{
    public class AddStockItemCommandHandler(
        IBranchStockRepository _branchStockRepository,
        IBookSupplyRepository _supplyRepository,
        IUnitOfWork _unitOfWork) : IRequestHandler<AddStockItemCommand, Result<Unit, Error>>
    {
        public async Task<Result<Unit, Error>> Handle(AddStockItemCommand request, CancellationToken cancellationToken)
        {
            BranchStockItem branchStockItem = BranchStockItem.Create(
                request.BranchId, request.BookSupplyDetailId, request.Count, request.DeliveryDate);

            int availableStock  = await _supplyRepository.GetSupplyDetailCountAsync(
                request.BookSupplyDetailId,cancellationToken);

            if (branchStockItem.Count > availableStock )
                return Result.Failure<Unit, Error>(Error.Conflict());

            await _branchStockRepository.AddStockItemAsync(branchStockItem, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success<Unit, Error>(Unit.Value);
        }
    }
}
