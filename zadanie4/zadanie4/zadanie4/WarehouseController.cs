using Microsoft.AspNetCore.Mvc;
using zadanie4.Model;

namespace zadanie4.zadanie4;

[Route("api/zad/orders")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private readonly IOrderService _orderService;

    public WarehouseController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        return Ok(await _orderService.GetOrders());
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] OrderDTO dto)
    {
        var success = await _orderService.AddOrder(dto);
        return success ? StatusCode(StatusCodes.Status201Created) : Conflict();
    }
}