/*using Microsoft.AspNetCore.Mvc;

namespace zadanie4.Model;

[Route("api/productwarehouses")]
[ApiController]
public class ProductWarehouseController : ControllerBase
{
    private readonly IProductWarehouseService _productWarehouseService;

    public ProductWarehouseController(IProductWarehouseService productWarehouseService)
    {
        _productWarehouseService = productWarehouseService;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetProductWarehouses()
    {
        return Ok(await _productWarehouseService.GetProductWarehouses());
    }

    [HttpGet("{IdProductWarehouse:int}")]
    public async Task<IActionResult> GetProductWarehouse([FromRoute] int IdProductWarehouse)
    {
        var success = await _productWarehouseService.GetProductWarehouse(IdProductWarehouse);
        return success != null ? Ok(success) : Conflict(Messages.ERR_NOT_FOUND);
    }

    [HttpPost]
    public async Task<IActionResult> AddProductWarehouse([FromBody] ProductWarehouseDTO dto)
    {
        var success = await _productWarehouseService.AddProductWarehouse(dto);
        return success ? StatusCode(StatusCodes.Status201Created) : Conflict();
    }

    [HttpPut("{IdProductWarehouse:int}")]
    public async Task<IActionResult> UpdateProductWarehouse([FromRoute] int IdProductWarehouse,
        [FromBody] ProductWarehouseDTO dto)
    {
        var success = await _productWarehouseService.UpdateProductWarehouse(IdProductWarehouse, dto);
        return success ? Ok() : Conflict(Messages.ERR_NOT_FOUND);
    }

    [HttpDelete("{IdProductWarehouse:int}")]
    public async Task<IActionResult> DeleteProductWarehouse([FromRoute] int IdProductWarehouse)
    {
        var success = await _productWarehouseService.DeleteProductWarehouse(IdProductWarehouse);
        return success ? Ok() : Conflict(Messages.ERR_NOT_FOUND);
    }
}*/