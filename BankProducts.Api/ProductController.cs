using BankProducts.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankProducts.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Account")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        public async Task<IActionResult> Account(CreateAccountDTO product)
        {
            Guid result = await mediator.Send(new CreateAccountProductCommand(product));
            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPost("CDT")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        public async Task<IActionResult> Post(CreateCDTDTO product)
        {
            Guid result = await mediator.Send(new CreateCDTProductCommand(product));
            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPost("Transaction")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Transaction(TransactionDTO transaction)
        {
            await mediator.Send(new TransactionCommand(transaction));
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPatch("Cancel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Cancel(CancelProductDTO cancelProduct)
        {
            await mediator.Send(new CancelProductCommad(cancelProduct));
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
