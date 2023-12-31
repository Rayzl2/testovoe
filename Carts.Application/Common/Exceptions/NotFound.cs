using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Common.Exceptions
{
    public class NotFound : Exception
    {
        // ВОЗВРАЩЕНИЕ НЕНАЙДЕННОЙ СВЯЗКИ НА ГЛОБАЛЬНОМ УРОВНЕ ПРИЛОЖЕНИЯ
        public NotFound(string name, object key) : base($"Entity {name}: {key} not found!") { }
    }
}
