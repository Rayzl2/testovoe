using AutoMapper;
using Carts.Application.Carts.Queries.GetGoodList;
using Microsoft.AspNetCore.Mvc;

namespace Carts.WebApi.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class GoodController : BaseController
    {
        private IMapper _mapper;

        public GoodController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Getting All goods from DB in this time 
        /// Получение всех товаров из БД на данный момент в системе
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        /// 
        ///         [GET] https://localhost:7294/api/good/
        /// Response:
        /// 
        ///         goods:[{
        ///             "goodName": "string",
        ///             "goodImg": "string",
        ///             "goodPrice": 0
        ///         }]
        ///
        /// </remarks>
        /// <response code="200">Result has got succes!
        /// Результат успешно получен!</response>
        /// <response code="401">Oops... Auth is failed
        /// Упс...Аутентификация не прошла :|</response>
        /// <response code="500">Intertnal Error. Get Callback from API developer. He will fix it all
        /// Ошибка сервера. Сообщите разработчику API. Он все починит</response>
        [HttpGet]
        //  [Authorize]
        public async Task<ActionResult<GoodListVM>> GetAll()
        {
            var query = new GetGoodList
            {


            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

    }
}
