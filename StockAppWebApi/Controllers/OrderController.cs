using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Extensions;
using StockAppWebApi.Services;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    readonly IOrderService _orderService;
    readonly IUserService _userService;
    public OrderController(IOrderService orderService, IUserService userService)
    {
        _orderService = orderService;
        _userService = userService;

    }
    [HttpPost("place_order")]
    public async Task<IActionResult> PlaceOrder(OrderViewModel orderViewModel)
    {
        int userId = HttpContext.GetUserId();
        var user = _userService.GetUserById(userId);
        if (user == null)
        {
            return BadRequest("User not found.");
        }
        orderViewModel.UserId = userId;
        var createOrder = await _orderService.CreateOrder(orderViewModel);
        return Ok(createOrder);
    }
}
