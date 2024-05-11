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

    public async Task<Product?> GetProduct(int IdProduct)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdProduct, Name, Description, Price FROM Product WHERE IdProduct = @id";
        cmd.Parameters.AddWithValue("@id", IdProduct);

        var dr = await cmd.ExecuteReaderAsync();
        if (await dr.ReadAsync())
        {
            return new Product
            {
                IdProduct = (int)dr["IdProduct"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Price = (decimal)dr["Price"]
            };
        }

        return null;
    }

    public async Task<bool> AddProduct(ProductDTO dto)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "INSERT INTO Product (Name, Description, Price) VALUES (@name, @description, @price)";
        cmd.Parameters.AddWithValue("@name", dto.Name);
        cmd.Parameters.AddWithValue("@description", dto.Description);
        cmd.Parameters.AddWithValue("@price", dto.Price);

        var affectedRows = await cmd.ExecuteNonQueryAsync();
        return affectedRows == 1;
    }

    public async Task<bool> UpdateProduct(int IdProduct, ProductDTO dto)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Product SET Name=@name, Description=@description, Price=@price WHERE IdProduct=@id";
        cmd.Parameters.AddWithValue("@name", dto.Name);
        cmd.Parameters.AddWithValue("@description", dto.Description);
        cmd.Parameters.AddWithValue("@price", dto.Price);
        cmd.Parameters.AddWithValue("@id", IdProduct);

        var affectedRows = await cmd.ExecuteNonQueryAsync();
        return affectedRows == 1;
    }

    public async Task<bool> DeleteProduct(int IdProduct)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE Product WHERE IdProduct=@id";
        cmd.Parameters.AddWithValue("@id", IdProduct);

        var affectedRows = await cmd.ExecuteNonQueryAsync();
        return affectedRows == 1;
    }
}