using Microsoft.AspNetCore.Mvc;

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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductWarehouses()
    {
        return Ok(await _productWarehouseService.GetProductWarehouses());
    }
}