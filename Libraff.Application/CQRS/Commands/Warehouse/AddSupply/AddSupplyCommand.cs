using Libraff.Application.CQRS.Dtos.Warehouse;

namespace Libraff.Application.CQRS.Commands.Warehouse.AddSupply
{
    public record AddSupplyCommand : IRequest<Result<Unit,Error>>
    {
        public string InvoiceNumber { get; set; }
        public int SupplierId { get; set; } 
        public DateTime SupplyDate {  get; set; } 
        public List<SupplyDetailDto>? BookItems { get; set; }

    }

    

}
