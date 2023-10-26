using Domain;
using Domain.DTO;
using Domain.Repository.IRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Commands
{
    public class PostCart : IRequest<HttpResponseMessage>
    {
        public string cartId { get; set; }
        public string customerId { get; set; }
        public List<ProductDTO> products { get; set; }
        public DateTime date { get; set; }
        public double total { get; set; }
        public double subtotal { get; set; }
    }
    public class PostCarttHandler : IRequestHandler<PostCart, HttpResponseMessage>


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

        public async Task<HttpResponseMessage> Handle(PostCart request, CancellationToken cancellationToken)
        {

            ShoppingCart newCart = new ShoppingCart();
            newCart.cartId = request.cartId;
            newCart.customerId = request.customerId;
            newCart.date = DateTime.Now;
            newCart.total = request.total;
            newCart.subTotal = request.subtotal;
            
            

            _repository.Add(newCart);

            foreach (var item in request.products)
            {
                var product =  _productRepository.GetById(item.productId);

                if (product == null)
                {
                    return null;
                }
                
                ProductCart productCart = new ProductCart();
                productCart.ProductoId = product.productId;
                productCart.CartId = newCart.cartId;
                productCart.ProductName = product.productName;
                productCart.ProductPrice = product.productPrice;
                productCart.Quantity = item.productQuantity;
                

                _detailRepository.Add(productCart);
            }

            var cartDTO = await _repository.GetCart(newCart.cartId);

            var url = "https://820cj4sr-7219.use2.devtunnels.ms/api/ShoppingCart";
            using var client = new HttpClient();
            
           
            var json = JsonConvert.SerializeObject(cartDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await client.PostAsync(url, data);

            if (!response.IsSuccessStatusCode)
            {
                var urlCola = "https://9ddslxzn-7185.use2.devtunnels.ms/api/ShoppingCart";
                using var clientCola = new HttpClient();

                var jsonCola = JsonConvert.SerializeObject(cartDTO);
                var dataCola = new StringContent(json, Encoding.UTF8, "application/json");


                var responseCola = await client.PostAsync(urlCola, dataCola);

                return responseCola;
            }

            return response;

        }
    }
}
