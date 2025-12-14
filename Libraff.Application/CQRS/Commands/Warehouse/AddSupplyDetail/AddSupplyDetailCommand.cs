
using Libraff.Application.CQRS.Dtos.Warehouse;

namespace Libraff.Application.CQRS.Commands.Warehouse.AddSupplyDetail
{
    public record AddSupplyDetailCommand : IRequest<Result<Unit, Error>>
    {
        public int SupplyId { get; set; }
        public IList<SupplyDetailDto>? BookItems { get; set; }

    }
}
