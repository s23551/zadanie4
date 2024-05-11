using Microsoft.AspNetCore.Mvc;

namespace zadanie4.Model;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts()
    {
        var productsTask = _productService.GetProducts();
        IEnumerable<Product> products;
        try
        {
            products = await productsTask;
        }
        catch
        {
            return Conflict();
        }
        return Ok(products);
    }
}