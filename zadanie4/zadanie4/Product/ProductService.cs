namespace zadanie4.Model;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _productRepository.GetProducts();
    }

    public async Task<Product?> GetProduct(int IdProduct)
    {
        return await _productRepository.GetProduct(IdProduct);
    }

    public async Task<bool> AddProduct(ProductDTO dto)
    {
        return await _productRepository.AddProduct(dto);
    }

    public async Task<bool> UpdateProduct(int IdProduct, ProductDTO dto)
    {
        return await _productRepository.UpdateProduct(IdProduct, dto);
    }

    public async Task<bool> DeleteProduct(int IdProduct)
    {
        return await _productRepository.DeleteProduct(IdProduct);
    }
}