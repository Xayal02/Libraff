
namespace Libraff.Application.CQRS.Commands.Warehouse.AddSupply
{
    public class AddSupplyCommandHandler(BookSupplyService _bookSupplyService, 
        IUnitOfWork _unitOfWork) : IRequestHandler<AddSupplyCommand, Result<Unit, Error>>
    {
        public async Task<Result<Unit, Error>> Handle(AddSupplyCommand request, CancellationToken cancellationToken)
        {
            List<BookSupplyDetail> bookSupplyDetails = new();
            foreach (var bookItem in request.BookItems)
            {
                bookSupplyDetails.Add(BookSupplyDetail.Create(bookItem.BookId, bookItem.PricePerBook, bookItem.Count));
            }

            await _bookSupplyService.CreateSupplyAsync(
                InvoiceNumber.Create(request.InvoiceNumber),
                request.SupplierId,
                request.SupplyDate,
                bookSupplyDetails,
                cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success<Unit, Error>(Unit.Value);
        }
    }
}
