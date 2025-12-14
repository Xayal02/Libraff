namespace Libraff.Application.CQRS.Commands.Warehouse.RejectTransfer
{
    public class RejectTransferCommand : IRequest<Result<Unit,Error>>
    {
        public int TransferRequestId { get; set; }
        public string Reason { get; set; }
        public int UserId { get; set; }
    }
}
