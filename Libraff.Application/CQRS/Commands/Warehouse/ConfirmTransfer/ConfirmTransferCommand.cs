namespace Libraff.Application.CQRS.Commands.Warehouse.ConfirmTransfer
{
    public class ConfirmTransferCommand : IRequest<Result<Unit,Error>>
    {
        public int TransferRequestId { get; set; }
        public int Count { get; set; }
        public int UserId { get; set; } // TODO As soon as I implement authentication  I will change it
        public DateTime? Date { get; set; } 

    }
}
