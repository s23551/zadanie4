using System.Data.SqlClient;

namespace zadanie4.Model;

public class ProductRepository : IProductRepository
{
    private readonly IConfiguration _configuration;

    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdProduct, Name, Description, Price FROM Product";

        var dr = await cmd.ExecuteReaderAsync();
        var products = new List<Product>();
        while (await dr.ReadAsync())
        {
            var product = new Product
            {
                IdProduct = (int)dr["IdProduct"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Price = (decimal)dr["Price"]
            };
            products.Add(product);
        }

        return products;
    }

    public async Task<Product> GetProduct(int IdProduct)
    {
        throw new NotImplementedException();
    }

    public bool AddProduct(ProductDTO dto)
    {
        throw new NotImplementedException();
    }

    public bool UpdateProduct(int IdProduct, ProductDTO dto)
    {
        throw new NotImplementedException();
    }

    public bool DeleteProduct(int IdProduct)
    {
        throw new NotImplementedException();
    }
}