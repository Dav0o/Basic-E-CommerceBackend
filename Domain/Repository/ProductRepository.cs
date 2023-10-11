using Domain.Data;
using Domain.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
            : base(context)
        {
            _context = context;
        }
        //public async Task<List<Product>> GetProductList()
        //{
        //    return await _context.Products.ToListAsync();
        //}

    }
}

