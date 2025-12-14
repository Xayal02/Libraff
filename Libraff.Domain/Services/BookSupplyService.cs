using Libraff.Domain.Constants;
using Libraff.Domain.Repositories;
using Libraff.Domain.Exceptions;

namespace Libraff.Domain.Services
{
    public class BookSupplyService(IBookSupplyRepository _supplyRepository)
    {
        public async Task CreateSupplyAsync(InvoiceNumber invoiceNumber, int supplierId, DateTime? supplyDate, IList<BookSupplyDetail>? bookItems, CancellationToken cancellationToken)
        {
            bool isCreated =  await _supplyRepository.IsExist(invoiceNumber,cancellationToken);

            if (isCreated)
                throw new ValidationException(DomainErrorMessages.DuplicateInvoiceNumber);

            BookSupply bookSupply = BookSupply.Create(invoiceNumber, supplierId, supplyDate,bookItems);

            await _supplyRepository.AddSuppliesAsync(bookSupply, cancellationToken);

        }

        public async Task AddBookItemAsync(int supplyId, IList<BookSupplyDetail> bookItems, CancellationToken cancellationToken)
        {
            if (supplyId <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(supplyId)));

            if (bookItems.Count == 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(bookItems)));

            foreach (var bookItem in bookItems)
            {
                BookSupplyDetail? supplyDetail = await _supplyRepository.GetBookSupplyDetailAsync(
                    supplyId, bookItem.BookId, cancellationToken);
                
                if (supplyDetail is null)
                    await _supplyRepository.AddSupplyDetailAsync(bookItem, supplyId, cancellationToken);
                else
                {
                    if (supplyDetail.PricePerBook != bookItem.PricePerBook)
                        throw new ValidationException(DomainErrorMessages.SupplyDetailPriceConflict);

                    await _supplyRepository.UpdateSupplyDetailCountAsync(supplyId, supplyDetail,bookItem.Count,cancellationToken);
                }
            }
        }

        public  async Task AddAdditionalBookItemAsync(int supplyId, IList<AddedBookSupplyDetail> bookItems,CancellationToken cancellationToken)
        {
            if (supplyId <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(supplyId)));

            if (bookItems.Count == 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(bookItems)));

            foreach (var bookItem in bookItems)
            {
                BookSupplyDetail? supplyDetail = await _supplyRepository.GetBookSupplyDetailAsync(
                    supplyId, bookItem.BookId, cancellationToken);

                if (supplyDetail is null)
                    throw new NotFoundException();
                else
                {
                    await _supplyRepository.UpdateSupplyDetailCountAsync(supplyId, supplyDetail, bookItem.Count, cancellationToken);
                }
            }
        }

        public async Task RemoveBookItemAsync(int supplyId, int bookId, CancellationToken cancellationToken)
        {
            if (supplyId <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(supplyId)));

            if (bookId <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(bookId)));

            BookSupplyDetail? supplyDetail = await _supplyRepository.GetBookSupplyDetailAsync(
                supplyId, bookId, cancellationToken);

            if (supplyDetail is null)
                throw new NotFoundException(""); 

            await _supplyRepository.RemoveSupplyDetailAsync(supplyId,supplyDetail,cancellationToken);
        }

    }
}
