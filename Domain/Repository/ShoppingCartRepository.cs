using Domain.Data;
using Domain.DTO;
using Domain.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
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

        public async Task<CartDTO> GetCart(int id)
        {
            ShoppingCart cart =  _context.ShoppingCarts
                .Include(c => c.ProductCarts)
                .ThenInclude(pc => pc.Producto)
                .FirstOrDefault(c => c.Id == id);

            if(cart == null)
            {
                return null;
            }
            CartDTO cartDTO = new CartDTO
            {
                Id = cart.Id,
                CustomerId = cart.UserId,
                Products = cart.ProductCarts.Select(pc => new ProductAddDTO
                {
                    ProductId = pc.ProductoId,
                    Quantity = pc.Quantity
                }).ToList(),
                Total = cart.Total,
                Date = cart.ShoppingDate
            };

            return cartDTO;
        }
    }
}
