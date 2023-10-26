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
    public class AddProduct : IRequest<Producto>
    {
        public string productId { get; set; }
        public string productName { get; set; }

        public double productPrice { get; set; }

    }

    public class AddProductHandler : IRequestHandler<AddProduct, Producto> 
      
       
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Producto> Handle(AddProduct request, CancellationToken cancellationToken)
        {
            Producto product = new Producto();
            product.productId = request.productId;
            product.productName = request.productName;
            product.productPrice = request.productPrice;
           

            _productRepository.Add(product);

            return product;
        }
    }
}
