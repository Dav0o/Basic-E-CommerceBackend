using Application.Commands;
using Application.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Product> PostAsync(AddProduct productRequest)
        {
            return await _mediator.Send(productRequest);
        }

        [HttpGet]
        public async Task<List<Product>> GeAsync()
        {
            return await _mediator.Send(new GetProducts());

        }
    }
}
