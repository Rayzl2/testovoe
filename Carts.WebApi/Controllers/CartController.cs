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
using System.Web.Http.Description;

namespace Carts.WebApi.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CartController : BaseController
    {

        private IMapper _mapper;

        public CartController(IMapper mapper) {
            _mapper = mapper;
        }

        /// <summary>
        /// Getting All active carts/sessions in this time 
        /// Получение всех активных сессий/корзин на данный момент в системе
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///         [GET] https://localhost:7294/api/cart/
        /// Response:
        /// 
        ///         carts:[{
        ///             "sessionId": "7c0d068b-73a9-47b4-8298-b5d15850b57f",
        ///             "goods": "string"
        ///         },
        ///         {
        ///             "sessionId": "9a2g068b-73a9-47b4-8298-c5a55830b17f",
        ///             "goods": "string"
        ///         }]
        ///
        /// </remarks>
        /// <response code="200">Result has got success!
        /// Результат успешно получен!</response>
        /// <response code="401">Oops... Auth is failed
        /// Упс...Аутентификация не прошла :|</response>
        /// <response code="500">Intertnal Error. Get Callback from API developer. He will fix it all
        /// Ошибка сервера. Сообщите разработчику API. Он все починит</response>
        [HttpGet]
      //  [Authorize]
        public async Task<ActionResult<CartListVM>> GetAll()
        {
            var query = new GetCartList
            {
               

            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }


        /// <summary>
        /// Getting details of current cart/session in this time 
        /// Получение деталей сессий/корзин на данный момент в системе
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///         [GET] https://localhost:7294/api/cart/7c0d068b-73a9-47b4-8298-b5d15850b57f     
        /// Response:
        /// 
        ///         carts:[{
        ///             "sessionId": "7c0d068b-73a9-47b4-8298-b5d15850b57f",
        ///             "goods": "string"
        ///         }]
        ///
        /// </remarks>
        /// <response code="200">Result has got success!
        /// Результат успешно получен!</response>
        /// <response code="401">Oops... Auth is failed
        /// Упс...Аутентификация не прошла :|</response>
        /// <response code="500">Intertnal Error. Get Callback from API developer. He will fix it all
        /// Ошибка сервера. Сообщите разработчику API. Он все починит</response>
        [HttpGet("{SessionId}")]
       // [Authorize]
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

        /// <summary>
        /// Creating new session for work
        /// Создание новой сессии для работы
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///         [POST] https://localhost:7294/api/cart/8d4f111e-42d5-11ee-be56-0242ac120001
        ///     
        /// Response:
        /// 
        ///         {SessiondId}
        ///     
        /// </remarks>
        /// <response code="204">Result has got success!
        /// Результат успешно получен!</response>
        /// <response code="401">Oops... Auth is failed
        /// Упс...Аутентификация не прошла :|</response>
        /// <response code="500">Intertnal Error. Get Callback from API developer. He will fix it all
        /// Ошибка сервера. Сообщите разработчику API. Он все починит</response>
        [HttpPost("{machineId}")]
       // [Authorize]
        public async Task<ActionResult<Guid>> Create([FromForm/*FromBody*/] CreateCartDto createCartDto, Guid machineId)
        {
            try
            {
                var command = _mapper.Map<CreateCart>(createCartDto);
                command.machineId = machineId;
                var cartId = await Mediator.Send(command);

                return Ok(cartId);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Updating session for work
        /// Обновление сессии для работы
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///         [PUT] https://localhost:7294/api/cart/8d4f111e-42d5-11ee-be56-0242ac120001/7c0d068b-73a9-47b4-8298-b5d15850b57f/1-Ferrero-249$;7-Сыр-120$
        ///     
        /// Response:
        /// 
        ///         NoContent
        ///     
        /// </remarks>
        /// <response code="204">Changes are supplied!
        /// Результат успешно получен!</response>
        /// <response code="401">Oops... Auth is failed
        /// Упс...Аутентификация не прошла :|</response>
        /// <response code="500">Intertnal Error. Get Callback from API developer. He will fix it all
        /// Ошибка сервера. Сообщите разработчику API. Он все починит</response>
        [HttpPut("{machineId}/{SessionId}/{Goods}")]
        //[ResponseType(typeof(IEnumerable<UpdateCart>))]
        //[Authorize]
        public async Task<ActionResult<Guid>> Update([FromForm/*FromBody*/] UpdateCartDto updateCartDto, string Goods, Guid SessionId, Guid machineId)
        {

            var command = _mapper.Map<UpdateCart>(updateCartDto);
            command.Goods = Goods;
            command.SessionId = SessionId;
            command.machineId = machineId;
            Console.WriteLine(Goods);
            Console.WriteLine(SessionId);
            var res = await Mediator.Send(command);
            Console.WriteLine(res);

            return NoContent();
        }


        /// <summary>
        /// Deleting session for fatal ending of work
        /// Принудительное удаление сессии
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///         [DELETE] https://localhost:7294/api/cart/8d4f111e-42d5-11ee-be56-0242ac120001/7c0d068b-73a9-47b4-8298-b5d15850b57f
        ///     
        /// Response:
        /// 
        ///         NoContent
        ///     
        /// </remarks>
        /// <response code="204">Result has got success!
        /// Результат успешно получен!</response>
        /// <response code="401">Oops... Auth is failed
        /// Упс...Аутентификация не прошла :|</response>
        /// <response code="500">Intertnal Error. Get Callback from API developer. He will fix it all
        /// Ошибка сервера. Сообщите разработчику API. Он все починит</response>
        [HttpDelete("{machineId}/{SessionId}")]
        //[Authorize]
        public async Task<IActionResult> Delete(Guid SessionId, Guid machineId)
        {
            var query = new DeleteCart
            {
                SessionId = SessionId,
                machineId = machineId
            };

            await Mediator.Send(query);

            return NoContent();
        }


    }
}
