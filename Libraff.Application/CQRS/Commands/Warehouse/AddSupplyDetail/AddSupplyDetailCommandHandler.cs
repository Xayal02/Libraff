
namespace Libraff.Application.CQRS.Commands.Warehouse.AddSupplyDetail
{
    public class AddSupplyDetailCommandHandler(BookSupplyService _bookSupplyService, IUnitOfWork _unitOfWork) : IRequestHandler<AddSupplyDetailCommand, Result<Unit, Error>>
    {
        public async Task<Result<Unit, Error>> Handle(AddSupplyDetailCommand request, CancellationToken cancellationToken)
        {

            List<BookSupplyDetail> bookSupplyDetails = new();

            foreach (var bookItem in request.BookItems)
            {
                bookSupplyDetails.Add(BookSupplyDetail.Create(bookItem.BookId, bookItem.PricePerBook, bookItem.Count));
            }


            await _bookSupplyService.AddBookItemAsync(request.SupplyId, bookSupplyDetails, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success<Unit, Error>(Unit.Value);
        }
    }
}
