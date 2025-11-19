namespace Libraff.Domain.Repositories
{
    public interface IStockRepository
    {
        Task AddStock();
        Task RemoveStock();
        Task UpdateStock();
        Task AddBranchStock();
        Task AddBranchDeliveryHistory();
        Task ConfirmBrachStockDelivery();
    }
}
