using Microsoft.AspNetCore.Mvc;

namespace zadanie4.Model;

[Route("api/warehouses")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetWarehouses()
    {
        return Ok(_warehouseService.GetWarehouses());
    }
}