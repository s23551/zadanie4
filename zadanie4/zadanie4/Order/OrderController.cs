using Microsoft.AspNetCore.Mvc;

namespace zadanie4.Model;

[Route("api/orders")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrders()
    {
        return Ok(await _orderService.GetOrders());
    }
}