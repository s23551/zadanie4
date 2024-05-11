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
    public async Task<IActionResult> GetWarehouses()
    {
        var warehousesTask = _warehouseService.GetWarehouses();
        IEnumerable<Warehouse> warehouses;

        try
        {
            warehouses = await warehousesTask;
        }
        catch
        {
            return Conflict();
        }
        return Ok(warehouses);
    }
}