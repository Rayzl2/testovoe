using AutoMapper;
using Carts.Application.Carts.Commands.CreatingCart;
using Carts.Application.Carts.Commands.DeletingCart;
using Carts.Application.Carts.Commands.UpdatingCart;
using Carts.Application.Carts.Queries.GetCartDetails;
using Carts.Application.Carts.Queries.GetCartList;
using Carts.Persistence;
using Carts.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<CartListVM>> GetAll()
        {
            var query = new GetCartList
            {
                machineId = Guid.Parse("8d4f111e-42d5-11ee-be56-0242ac120001")

            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{SessionId}")]
        [Authorize]
        public async Task<ActionResult<CartDetailsVM>> GetCart(Guid SessionId)
        {
            try
            {
                var query = new GetCartDetails
                {
                   SessionId = SessionId
                };

                var vm = await Mediator.Send(query);

                return Ok(vm);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCartDto createCartDto)
        {
            try
            {
                var command = _mapper.Map<CreateCart>(createCartDto);
                command.machineId = new Guid();
                var cartId = await Mediator.Send(command);

                return Ok(cartId);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateCartDto updateCartDto)
        {
            var command = _mapper.Map<UpdateCart>(updateCartDto);
            command.machineId = new Guid("8d4f111e-42d5-11ee-be56-0242ac120002");
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{SessionId}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid SessionId)
        {
            var query = new DeleteCart
            {
                SessionId = SessionId,
                machineId = new Guid("8d4f111e-42d5-11ee-be56-0242ac120002")
            };

            await Mediator.Send(query);

            return NoContent();
        }


    }
}
