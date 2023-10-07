using Domain;
using Domain.Repository;
using Domain.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetProducts : IRequest<List<Product>>

    { 
    }


    public class GetProductsHandler : IRequestHandler<GetProducts, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(GetProducts request, CancellationToken cancellationToken)
        {
            List<Product> products = await Task.Run(() =>
            {
                return _productRepository.GetAll();
            });

            return products;
        }
    }
    }


