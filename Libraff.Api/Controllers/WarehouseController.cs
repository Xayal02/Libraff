using Libraff.Application.CQRS.Commands.Warehouse.AddAdditionalSupplyDetail;
using Libraff.Application.CQRS.Commands.Warehouse.AddStockItem;
using Libraff.Application.CQRS.Commands.Warehouse.AddSupply;
using Libraff.Application.CQRS.Commands.Warehouse.AddSupplyDetail;
using Libraff.Application.CQRS.Commands.Warehouse.ConfirmTransfer;
using Libraff.Application.CQRS.Commands.Warehouse.MakeTransfer;
using Libraff.Application.CQRS.Commands.Warehouse.RejectTransfer;

namespace Libraff.Api.Controllers
{
    [ApiController]
    [Route("api/v1/warehouse")]
    public class WarehouseController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("supply")]
        public async Task<IActionResult> AddSupply(AddSupplyCommand command)
        {
            var responseData = await _mediator.Send(command);

            if (responseData.IsSuccess)
                return Ok();
            else
                return Problem(responseData.Error.Message, statusCode: responseData.Error.Code);
        }

        [HttpPost("supply-detail")]
        
        public async Task<IActionResult> AddSupplyDetail(AddSupplyDetailCommand command)
        {
            var responseData = await _mediator.Send(command);

            if (responseData.IsSuccess)
                return Ok();
            else
                return Problem(responseData.Error.Message, statusCode: responseData.Error.Code);
        }

        [HttpPut("supply-detail")]

        public async Task<IActionResult> AddAdditionalSupplyDetail(AddAdditionalSupplyDetailCommand command)
        {
            var responseData = await _mediator.Send(command);

            if (responseData.IsSuccess)
                return Ok();
            else
                return Problem(responseData.Error.Message, statusCode: responseData.Error.Code);
        }

        [HttpPost("stock-item")]
        public async Task<IActionResult> AddStockItem(AddStockItemCommand command)
        {
            var responseData = await _mediator.Send(command);

            if (responseData.IsSuccess)
                return Ok();
            else
                return Problem(responseData.Error.Message, statusCode: responseData.Error.Code);
        }


        [HttpPost("transfer/request")]
        public async Task<IActionResult> RequestTransfer(RequestTransferCommand command)
        {
            var responseData = await _mediator.Send(command);

            if (responseData.IsSuccess)
                return Ok();
            else
                return Problem(responseData.Error.Message, statusCode: responseData.Error.Code);
        }

        [HttpPut("transfer/confirm")]
        public async Task<IActionResult> ConfirmTransfer(ConfirmTransferCommand command)
        {
            var responseData = await _mediator.Send(command);

            if (responseData.IsSuccess)
                return Ok();
            else
                return Problem(responseData.Error.Message, statusCode: responseData.Error.Code);
        }

        [HttpPut("transfer/reject")]
        public async Task<IActionResult> RejectTransfer(RejectTransferCommand command)
        {
            var responseData = await _mediator.Send(command);

            if (responseData.IsSuccess)
                return Ok();
            else
                return Problem(responseData.Error.Message, statusCode: responseData.Error.Code);
        }
    }
}
