using Domain;
using Domain.DTO;
using Domain.Repository.IRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class PostCart : IRequest<CartDTO>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<ProductAddDTO> Products { get; set; }
        public DateTime Date { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
    }
    public class PostCarttHandler : IRequestHandler<PostCart, CartDTO>


    {
        private readonly IShoppingCartRepository _repository;
        private readonly IDetailsRepository _detailRepository;
        private readonly IProductRepository _productRepository;

        public PostCarttHandler(IShoppingCartRepository repository, IDetailsRepository detailRepository,IProductRepository productRepository)
        {
            _repository = repository;
            _detailRepository = detailRepository;
            _productRepository = productRepository;
        }

        public Task<CartDTO> Handle(PostCart request, CancellationToken cancellationToken)
        {

            ShoppingCart newCart = new ShoppingCart();
            newCart.Id = request.Id;
            newCart.Total = request.Total;
            newCart.SubTotal = request.SubTotal;
            newCart.ShoppingDate = DateTime.Now;

            _repository.Add(newCart);

            foreach (var item in request.Products)
            {
                var product =  _productRepository.GetById(item.ProductId);

                if (product == null)
                {
                    return null;
                }

                ProductCart productCart = new ProductCart();
                productCart.ProductoId = product.Id;
                productCart.CartId = newCart.Id;
                productCart.Quantity = item.Quantity;

                _detailRepository.Add(productCart);
            }
            

            return _repository.GetCart(newCart.Id);

        }
    }
}
