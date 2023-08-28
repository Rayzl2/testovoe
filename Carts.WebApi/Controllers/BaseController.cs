using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace Carts.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal Guid machineId => !User.Identity.IsAuthenticated ? Guid.Empty : 
            Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        internal Guid SessionId => !User.Identity.IsAuthenticated ? Guid.Empty :
            Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        internal Guid Goods => !User.Identity.IsAuthenticated ? Guid.Empty :
            Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
