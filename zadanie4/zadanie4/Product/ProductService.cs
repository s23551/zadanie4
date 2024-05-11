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

    public async Task<Product> GetProduct(int IdProduct)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddProduct(ProductDTO dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateProduct(int IdProduct, ProductDTO dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteProduct(int IdProduct)
    {
        throw new NotImplementedException();
    }
}