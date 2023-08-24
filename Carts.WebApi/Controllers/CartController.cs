using AutoMapper;
using Carts.Application.Carts.Commands.CreatingCart;
using Carts.Application.Carts.Commands.DeletingCart;
using Carts.Application.Carts.Commands.UpdatingCart;
using Carts.Application.Carts.Queries.GetCartDetails;
using Carts.Application.Carts.Queries.GetCartList;
using Carts.Persistence;
using Carts.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Carts.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class CartController : BaseController
    {

        private IMapper _mapper;

        public CartController(IMapper mapper) {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CartListVM>> GetAll()
        {
            var query = new GetCartList
            {
                
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{SessionId}")]
        public async Task<ActionResult<CartDetailsVM>> GetCart()
        {
            try
            {
                var query = new GetCartDetails
                {
                   // SessionId = SessionId
                };

                var vm = await Mediator.Send(1);

                return Ok(vm);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCartDto createCartDto)
        {
            var command = _mapper.Map<CreateCart>(createCartDto);
            // Развитие под идентификаю машин command.machineId = machineId;
            var cartId = await Mediator.Send(command);

            return Ok(cartId);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateCartDto updateCartDto)
        {
            var command = _mapper.Map<UpdateCart>(updateCartDto);
            // Развитие под идентификаю машин command.machineId = machineId;
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{SessionId}")]
        public async Task<IActionResult> Delete(Guid SessionId)
        {
            var query = new DeleteCart
            {
                SessionId = SessionId
            };

            await Mediator.Send(query);

            return NoContent();
        }


    }
}
