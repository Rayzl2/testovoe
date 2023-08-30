using FluentValidation;

namespace Carts.Application.Carts.Commands.CreatingCart
{
    public class CreateCartValidation :AbstractValidator<CreateCart>
    {

        public CreateCartValidation() {
            // ГЛАВНОЕ ЧТОБЫ ID МАШИНЫ НЕ БЫЛ ПУСТЫМ
            RuleFor(createCart => createCart.machineId).NotEqual(Guid.Empty);
        }

    }
}
