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
    public async Task<IActionResult> GetOrders()
    {
        return Ok(await _orderService.GetOrders());
    }

    [HttpGet("{IdOrder:int}")]
    public async Task<IActionResult> GetOrder([FromRoute] int IdOrder)
    {
        var success = await _orderService.GetOrder(IdOrder);
        return success != null ? Ok(success) : Conflict(Messages.ERR_NOT_FOUND);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] OrderDTO dto)
    {
        var success = await _orderService.AddOrder(dto);
        return success ? StatusCode(StatusCodes.Status201Created) : Conflict();
    }

    [HttpPut("{IdOrder:int}")]
    public async Task<IActionResult> UpdateOrder([FromRoute] int IdOrder, [FromBody] OrderDTO dto)
    {
        var success = await _orderService.UpdateOrder(IdOrder, dto);
        return success ? Ok() : Conflict(Messages.ERR_NOT_FOUND);
    }

    [HttpDelete("{IdOrder:int}")]
    public async Task<IActionResult> DeleteOrder([FromRoute] int IdOrder)
    {
        var success = await _orderService.DeleteOrder(IdOrder);
        return success ? Ok() : Conflict(Messages.ERR_NOT_FOUND);
    }
}