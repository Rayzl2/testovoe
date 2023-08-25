using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Commands.UpdatingCart
{
    public class UpdateCartValidation : AbstractValidator<UpdateCart>
    {
        public UpdateCartValidation() {
            RuleFor(updateCart => updateCart.machineId).NotEqual(Guid.Empty);
            RuleFor(updateCart => updateCart.SessionId).NotEqual(Guid.Empty);
        }
    }
}
