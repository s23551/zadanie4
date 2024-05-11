namespace zadanie4.Model;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product?> GetProduct(int IdProduct);
    Task<bool> AddProduct(ProductDTO dto);
    Task<bool> UpdateProduct(int IdProduct, ProductDTO dto);
    Task<bool> DeleteProduct(int IdProduct);

}