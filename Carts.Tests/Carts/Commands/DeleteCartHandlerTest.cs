using Xunit;
using Carts.Tests.Common;
using Carts.Application.Carts.Commands.DeletingCart;
using Carts.Application.Common.Exceptions;
using Carts.Application.Carts.Commands.CreatingCart;

namespace Carts.Tests.Carts.Commands
{
    public class DeleteNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteCartHandler_Success()
        {
            // Arrange
            var handler = new DeleteCartHandler(_context);

            // Act
            await handler.Handle(new DeleteCart
            {
                SessionId = CartsContextFactory.CartIdForDelete,
                machineId = CartsContextFactory.machineAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(_context.Carts.SingleOrDefault(cart =>
                cart.SessionId == CartsContextFactory.CartIdForDelete));
        }

        [Fact]
        public async Task DeleteCartHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteCartHandler(_context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFound>(async () =>
                await handler.Handle(
                    new DeleteCart
                    {
                        SessionId = Guid.NewGuid(),
                        machineId = CartsContextFactory.machineAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeletCartHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteCartHandler(_context);
            var createHandler = new CreateCartHandler(_context);
            var cartId = await createHandler.Handle(
                new CreateCart
                {
                    Goods = "СодержаниеКорзины",
                    machineId = CartsContextFactory.machineAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFound>(async () =>
                await deleteHandler.Handle(
                    new DeleteCart
                    {
                        SessionId = cartId,
                        machineId = CartsContextFactory.machineBId
                    }, CancellationToken.None));
        }
    }
}