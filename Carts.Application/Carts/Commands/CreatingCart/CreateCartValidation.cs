using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Commands.CreatingCart
{
    public class CreateCartValidation :AbstractValidator<CreateCart>
    {

        public CreateCartValidation() {
            RuleFor(createCart => createCart.machineId).NotEqual(Guid.Empty);
        }

    }
}
