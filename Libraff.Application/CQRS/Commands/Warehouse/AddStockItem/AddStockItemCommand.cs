namespace Libraff.Application.CQRS.Commands.Warehouse.AddStockItem
{
    public record AddStockItemCommand : IRequest<Result<Unit,Error>>
    {
        public int BranchId { get; set; }
        public int BookSupplyDetailId { get; set; }
        public int Count { get; set; }
        public DateOnly? DeliveryDate { get; set; }
    }
}
