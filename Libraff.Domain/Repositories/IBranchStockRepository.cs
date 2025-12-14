namespace Libraff.Domain.Repositories
{
    public interface IBranchStockRepository
    {
        Task AddStockItemAsync(BranchStockItem branchStockItem, CancellationToken cancellationToken);
        Task AddStockItemTransferRequestAsync(TransferableBranchStockItem transferableBranchStockItem, CancellationToken cancellationToken);
        Task<TransferableBranchStockItem?> GetStockItemTransferRequestById(int id, CancellationToken cancellationToken);
        void UpdateStockItemTransferRequest(TransferableBranchStockItem transferableBranchStockItem);
        Task MarkConfirmedTransfersAsDelivered();
        Task<BranchStockItem?> GetStockItemByIdAsync(int id, CancellationToken cancellationToken);
    }
}
