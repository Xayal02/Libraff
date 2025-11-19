using Libraff.Domain.Constants;
using Libraff.Domain.Repositories;

namespace Libraff.Domain.Services
{
    public class BookSupplyService(IBookSupplyRepository _supplyRepository)
    {
        public async Task CreateSupplyAsync(InvoiceNumber invoiceNumber, int supplierId, DateTime? supplyDate, IList<BookSupplyDetail>? bookItems, CancellationToken cancellationToken)
        {
            bool isCreated =  await _supplyRepository.IsExist(invoiceNumber,cancellationToken);

            if (isCreated)
                throw new InvalidOperationException(); // errorMessage

            BookSupply bookSupply = BookSupply.Create(invoiceNumber, supplierId, supplyDate,bookItems);

            await _supplyRepository.AddSuppliesAsync(bookSupply, cancellationToken);

        }
    }
}
