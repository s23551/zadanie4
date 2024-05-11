namespace zadanie4.Model;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProduct(int IdProduct);
    bool AddProduct(ProductDTO dto);
    bool UpdateProduct(int IdProduct, ProductDTO dto);
    bool DeleteProduct(int IdProduct);
}