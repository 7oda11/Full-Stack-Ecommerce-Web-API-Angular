using Ecom.Core.DTO;
using Ecom.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpPost("create-order")]
        public async Task<IActionResult> Create(OrderDTO orderDTO)
        {
            var email = User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.Email)?.Value;
            var order=await orderService.CreateOrderAsync(orderDTO,email);
            return Ok(order);
        }
    }
}
