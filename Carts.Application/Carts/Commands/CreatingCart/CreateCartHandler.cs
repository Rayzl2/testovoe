using MediatR;
using Carts.Domain;
using Carts.Application.Interfaces;

namespace Carts.Application.Carts.Commands.CreatingCart
{
    public class CreateCartHandler : IRequestHandler<CreateCart, Guid>
    {

        private readonly ICartsDBContext _dbContext;
        public CreateCartHandler(ICartsDBContext dbContext) =>
    
            _dbContext = dbContext;
        
        public async Task<Guid> Handle(CreateCart request, CancellationToken cancellationToken)
        {
            // СОЗДАНИЕ НОВОГО ЭКЗЕМПЛЯРА КЛАССА
            var cart = new Cart
            {
                machineId = request.machineId,
                SessionId = Guid.NewGuid(),
                Goods = "Корзина пуста"
            };
           // _dbContext.Carts.Attach(cart);

            // СОХРАНЕНИЕ ЭКЗЕМПЛЯРА КЛАССА В БД
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return cart.SessionId;
        }
    }
}
