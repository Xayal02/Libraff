namespace Libraff.Domain.Repositories
{
    public interface IBookSupplyRepository
    {
        Task AddSuppliesAsync(BookSupply supply, CancellationToken cancellationToken);
        Task UpdateSupplyAsync(BookSupply supply, CancellationToken cancellationToken);
        Task<BookSupply> GetSupplyByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> IsExist(InvoiceNumber invoiceNumber, CancellationToken cancellationToken);
    }
}
