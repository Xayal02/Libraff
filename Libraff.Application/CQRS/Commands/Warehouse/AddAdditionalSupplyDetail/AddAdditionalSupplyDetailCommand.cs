using Libraff.Application.CQRS.Dtos.Warehouse;

namespace Libraff.Application.CQRS.Commands.Warehouse.AddAdditionalSupplyDetail
{
    public class AddAdditionalSupplyDetailCommand : IRequest<Result<Unit,Error>>
    {
        public int SupplyId { get; set; }
        public IList<AddedBookSupplyDetailDto>? BookItems { get; set; }

    }


}
