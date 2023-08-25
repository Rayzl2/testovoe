using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Queries.GetCartDetails
{
    public class CartDetailsValidator : AbstractValidator<GetCartDetails>
    {
        public CartDetailsValidator() {
            RuleFor(cartDetails => cartDetails.SessionId).NotEqual(Guid.Empty);
          //  RuleFor(cartDetails => cartDetails.machineId).NotEqual(Guid.Empty);
        }
    }
}
