using Domain.Data;
using Domain.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly MyDbContext _context;

        public ShoppingCartRepository(MyDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
