using Domain;
using Domain.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetProducyById : IRequest<Producto>
    {
        public string Id { get; set; }

        public GetProducyById(string id)
        {
            Id = id;
        }
    }

    public class GetProductByIdHandler : IRequestHandler<GetProducyById, Producto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public  async Task<Producto> Handle(GetProducyById request, CancellationToken cancellationToken)
        {
            return  _productRepository.GetById(request.Id);
        }

       
    }
}
