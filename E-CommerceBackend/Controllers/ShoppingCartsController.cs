using Application.Commands;
using Domain;
using Domain.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private IMediator _mediator;

        public ShoppingCartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CartDTO> PostAsync(PostCart request)
        {
            return await _mediator.Send(request);
        }
    }
}
