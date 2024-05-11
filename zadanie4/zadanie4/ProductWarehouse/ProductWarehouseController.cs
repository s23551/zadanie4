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
        var productWarehousesTask = _productWarehouseService.GetProductWarehouses();
        IEnumerable<ProductWarehouse> productWarehouses;

        try
        {
            productWarehouses = await productWarehousesTask;
        }
        catch
        {
            return Conflict();
        }
        return Ok(productWarehouses);
    }
}