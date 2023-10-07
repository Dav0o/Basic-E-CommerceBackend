using Domain;
using Domain.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class AddProduct : IRequest<Product>
    {
        public string Name { get; set; } = string.Empty;

        public int Price { get; set; }
    }

    public class AddProductHandler : IRequestHandler<AddProduct, Product> 
      
       
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(AddProduct request, CancellationToken cancellationToken)
        {
            Product product = new Product();
            product.Name = request.Name;
            product.Price = request.Price;

            return product;
        }
    }
}
