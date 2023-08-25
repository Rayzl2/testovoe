using Carts.Application.Carts.Commands.UpdatingCart;
using Carts.Application.Common.Exceptions;
using Carts.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Notes.Tests.Notes.Commands
{
    public class UpdateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateCartHandler_Success()
        {
            // Arrange
            var handler = new UpdateCartHandler(_context);
            var updatedCart = "эта корзина обновлена";

            // Act
            await handler.Handle(new UpdateCart
            {
                SessionId = CartsContextFactory.CartIdForUpdate,
                machineId = CartsContextFactory.machineBId,
                Goods = updatedCart
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await _context.Carts.SingleOrDefaultAsync(cart =>
                cart.SessionId == CartsContextFactory.CartIdForUpdate &&
                cart.Goods == updatedCart));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateCartHandler(_context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFound>(async () =>
                await handler.Handle(
                    new UpdateCart
                    {
                        SessionId = Guid.NewGuid(),
                        machineId = CartsContextFactory.machineAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateCartHandler(_context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFound>(async () =>
            {
                await handler.Handle(
                    new UpdateCart
                    {
                        SessionId = CartsContextFactory.CartIdForUpdate,
                        machineId = CartsContextFactory.machineAId
                    },
                    CancellationToken.None);
            });
        }
    }
}