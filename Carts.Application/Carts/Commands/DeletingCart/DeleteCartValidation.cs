using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Commands.DeletingCart
{
    public class DeleteCartValidation : AbstractValidator<DeleteCart>
    {
        public DeleteCartValidation() {
            RuleFor(deleteCart => deleteCart.machineId).NotEqual(Guid.Empty);
            RuleFor(deleteCart => deleteCart.SessionId).NotEqual(Guid.Empty);
        }
    }
}
