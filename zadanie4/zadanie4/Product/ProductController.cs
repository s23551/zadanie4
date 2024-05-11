using Microsoft.AspNetCore.Http.HttpResults;
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
    public async Task<IActionResult> GetProducts()
    {
        return Ok(await _productService.GetProducts());
    }

    [HttpGet("{IdProduct:int}")]
    public async Task<IActionResult> GetProduct([FromRoute] int IdProduct)
    {
        var success = await _productService.GetProduct(IdProduct);
        return success != null ? Ok(success) : Conflict(Messages.ERR_NOT_FOUND);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] ProductDTO dto)
    {
        var success = await _productService.AddProduct(dto);
        return success ? StatusCode(StatusCodes.Status201Created) : Conflict();
    }

    [HttpPut("{IdProduct:int}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int IdProduct, [FromBody] ProductDTO dto)
    {
        var success = await _productService.UpdateProduct(IdProduct, dto);
        return success ? Ok() : Conflict();
    }

    [HttpDelete("{IdProduct:int}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int IdProduct)
    {
        var success = await _productService.DeleteProduct(IdProduct);
        return success ? Ok() : Conflict();
    }
}