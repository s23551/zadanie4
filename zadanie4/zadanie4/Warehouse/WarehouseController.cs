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
    public async Task<IActionResult> GetWarehouses()
    {
        return Ok(await _warehouseService.GetWarehouses());
    }

    [HttpGet("{IdWarehouse:int}")]
    public async Task<IActionResult> GetWarehouse([FromRoute] int IdWarehouse)
    {
        var success = await _warehouseService.GetWarehouse(IdWarehouse);
        return success != null ? Ok(success) : Conflict(Messages.ERR_NOT_FOUND);
    }

    [HttpPost]
    public async Task<IActionResult> AddWarehouse([FromBody] WarehouseDTO dto)
    {
        var success = await _warehouseService.AddWarehouse(dto);
        return success ? StatusCode(StatusCodes.Status201Created) : Conflict();
    }

    [HttpPut("{IdWarehouse:int}")]
    public async Task<IActionResult> UpdateWarehouse([FromRoute] int IdWarehouse, [FromBody] WarehouseDTO dto)
    {
        var success = await _warehouseService.UpdateWarehouse(IdWarehouse, dto);
        return success ? Ok() : Conflict(Messages.ERR_NOT_FOUND);
    }

    [HttpDelete("{IdWarehouse:int}")]
    public async Task<IActionResult> DeleteWarehouse([FromRoute] int IdWarehouse)
    {
        var success = await _warehouseService.DeleteWarehouse(IdWarehouse);
        return success ? Ok() : Conflict(Messages.ERR_NOT_FOUND);
    }
}