using Carts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Tests.Common
{
    public class TestCommandBase : IDisposable
    { 
        protected readonly CartsDbContext _context;

        public TestCommandBase()
        {
            _context = CartsContextFactory.Create();
        }

        public void Dispose()
        {
            CartsContextFactory.Destroy(_context);
        }
    }

  
}
