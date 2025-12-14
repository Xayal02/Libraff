namespace Libraff.Application.CQRS.Commands.Warehouse.AddAdditionalSupplyDetail
{
    public class AddAdditionalSupplyDetailCommandHandler(BookSupplyService _bookSupplyService, IUnitOfWork _unitOfWork ) : IRequestHandler<AddAdditionalSupplyDetailCommand, Result<Unit, Error>>
    {
        public async  Task<Result<Unit, Error>> Handle(AddAdditionalSupplyDetailCommand request, CancellationToken cancellationToken)
        {
            List<AddedBookSupplyDetail> bookSupplyDetails = new();
            foreach (var bookItem in request.BookItems)
            {
                bookSupplyDetails.Add(AddedBookSupplyDetail.Create(bookItem.BookId,bookItem.Count));
            }

            await _bookSupplyService.AddAdditionalBookItemAsync(
                request.SupplyId,
                bookSupplyDetails,
                cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success<Unit, Error>(Unit.Value);
        }
    }
}
