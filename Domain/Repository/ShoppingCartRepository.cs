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

        public async Task<CartDTO> GetCart(string id)
        {
            ShoppingCart cart =  _context.ShoppingCarts
                .Include(c => c.ProductCarts)
                .ThenInclude(pc => pc.Producto)
                .FirstOrDefault(c => c.cartId == id);

            if(cart == null)
            {
                return null;
            }
            CartDTO cartDTO = new CartDTO
            {
                cartId = cart.cartId,
                customerId = cart.customerId,
                products = cart.ProductCarts.Select(pc => new ProductDTO
                {
                    productId = pc.ProductoId,
                    productName = pc.ProductName,
                    productPrice = pc.ProductPrice,
                    productQuantity = pc.Quantity
                }).ToList(),
                date = cart.date,
                total = cart.total,
                subtotal = cart.subTotal
                
            };

            return cartDTO;
        }
    }
}
