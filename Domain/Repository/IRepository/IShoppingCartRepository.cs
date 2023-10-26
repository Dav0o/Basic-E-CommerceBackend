using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.IRepository
{
    public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
    {
       public Task<CartDTO> GetCart(string id);

    }
}
