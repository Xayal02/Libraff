namespace Libraff.Application.CQRS.Dtos.Warehouse
{
    public class SupplyDetailDto
    {
        public int BookId { get; set; }
        public decimal PricePerBook { get; set; }
        public int Count { get; set; }
    }
}
