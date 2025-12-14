namespace Libraff.Application.CQRS.Commands.Warehouse.MakeTransfer
{
    public class RequestTransferCommand : IRequest<Result<Unit,Error>>
    {
        public int BranchStockItemId { get; set; }
        public int ToBranchId { get; set; }
        public int Count { get; set; }
        public int UserId { get; set; } = 1; // As soons as I implement authentication  I will change it
        public DateTime? Date { get; set; }
   
    }
}
