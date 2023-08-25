using Carts.Application.Carts.Commands.CreatingCart;
using Carts.Persistence;
using Carts.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Carts.Tests.Carts.Commands
{
    public class CreateCartHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task CreateCartHandler_Success()
        {
            var handler = new CreateCartHandler(_context);
            var goodsDetails = "filling of cart";

            var cartId = await handler.Handle(
                new CreateCart
                {
                    machineId = CartsContextFactory.machineAId,
                    Goods = goodsDetails,

                }, CancellationToken.None);

            Assert.NotNull(await _context.Carts.SingleOrDefaultAsync(cart =>
            cart.SessionId == cartId && cart.Goods == goodsDetails));
        }

    }
}
