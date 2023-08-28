using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Queries.GetCartList
{
    public class GetCartListValidator : AbstractValidator<GetCartList>
    {
        public GetCartListValidator() {
            //RuleFor(cartList => cartList.machineId).NotEqual(Guid.Empty);
        }
    }
}
