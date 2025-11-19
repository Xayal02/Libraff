using System.Reflection.Metadata.Ecma335;

namespace Libraff.Application.CQRS.Commands.Warehouse.AddSupply
{
    public record AddSupplyCommand : IRequest<Result<Unit,Error>>
    {
        public string InvoiceNumber { get; set; }
        public int SupplierId { get; set; } 
        public DateTime SupplyDate {  get; set; } 
        public List<SomeClass>? BookItems { get; set; }

    }

    public class SomeClass
    {
        public int BookId { get; set; }
        public decimal PricePerBook { get; set; }
        public int Count { get; set; }
    }

}
