using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.IRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
     //   public Task<List<Product>> GetProductList();
    }
}
