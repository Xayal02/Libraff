using System.Runtime.InteropServices;

namespace Libraff.Domain.Repositories
{
    public interface IBookSupplyRepository
    {
        Task AddSuppliesAsync(BookSupply supply, CancellationToken cancellationToken);
        Task<BookSupply> GetSupplyByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> IsExist(InvoiceNumber invoiceNumber, CancellationToken cancellationToken);
        Task<BookSupplyDetail?> GetBookSupplyDetailAsync(int supplierId, int bookId,  CancellationToken cancellationToken);
        Task AddSupplyDetailAsync(BookSupplyDetail bookSupplyDetail, int supplyId, CancellationToken cancellationToken);
        Task UpdateSupplyDetailAsync(int supplyId, BookSupplyDetail bookSupplyDetail,CancellationToken cancellationToken);
        Task UpdateSupplyDetailCountAsync(int supplyId, BookSupplyDetail bookSupplyDetail, int count, CancellationToken cancellationToken);
        Task RemoveSupplyDetailAsync(int supplyId, BookSupplyDetail bookSupplyDetail, CancellationToken cancellationToken);
        Task<int> GetSupplyDetailCountAsync(int supplyDetailId, CancellationToken cancellationToken);
    }
}
