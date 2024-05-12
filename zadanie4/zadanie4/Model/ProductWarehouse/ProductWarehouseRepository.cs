using System.Data.SqlClient;

namespace zadanie4.Model;

public class ProductWarehouseRepository : IProductWarehouseRepository
{
    private readonly IConfiguration _configuration;

    public ProductWarehouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<ProductWarehouse>> GetProductWarehouses()
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "SELECT IdProductWarehouse, IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt FROM Product_Warehouse";

        var dr = await cmd.ExecuteReaderAsync();
        var productWarehouses = new List<ProductWarehouse>();

        while (await dr.ReadAsync())
        {
            var productWarehouse = new ProductWarehouse
            {
                IdProductWarehouse = (int)dr["IdProductWarehouse"],
                IdWarehouse = (int)dr["IdWarehouse"],
                IdProduct = (int)dr["IdProduct"],
                IdOrder = (int)dr["IdOrder"],
                Amount = (int)dr["Amount"],
                Price = (decimal)dr["Price"],
                CreatedAt = (DateTime)dr["CreatedAt"]
            };
            productWarehouses.Add(productWarehouse);
        }

        return productWarehouses;
    }

    public async Task<ProductWarehouse?> GetProductWarehouse(int IdProductWarehouse)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "SELECT IdProductWareHouse, IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt " +
            "FROM Product_Warehouse WHERE IdProductWarehouse=@id";
        cmd.Parameters.AddWithValue("@id", IdProductWarehouse);

        var dr = await cmd.ExecuteReaderAsync();
        if (await dr.ReadAsync())
        {
            var productWarehouse = new ProductWarehouse
            {
                IdProductWarehouse = (int)dr["IdProductWarehouse"],
                IdWarehouse = (int)dr["IdWarehouse"],
                IdProduct = (int)dr["IdProduct"],
                IdOrder = (int)dr["IdOrder"],
                Amount = (int)dr["Amount"],
                Price = (decimal)dr["Price"],
                CreatedAt = (DateTime)dr["CreatedAt"]
            };
            return productWarehouse;
        }

        return null;
    }

    public async Task<bool> AddProductWarehouse(ProductWarehouseDTO dto)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "INSERT INTO Product_Warehouse (IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) " +
            "VALUES (@idWarehouse, @idProduct, @idOrder, @amount, @price, @createdAt)";
        cmd.Parameters.AddWithValue("@idWarehouse", dto.IdWarehouse);
        cmd.Parameters.AddWithValue("@idProduct", dto.IdProduct);
        cmd.Parameters.AddWithValue("@idOrder", dto.IdOrder);
        cmd.Parameters.AddWithValue("@amount", dto.Amount);
        cmd.Parameters.AddWithValue("@price", dto.Price);
        cmd.Parameters.AddWithValue("@createdAt", dto.CreatedAt);

        var affectedRows = await cmd.ExecuteNonQueryAsync();
        return affectedRows == 1;
    }

    public async Task<bool> UpdateProductWarehouse(int IdProductWarehouse, ProductWarehouseDTO dto)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "UPDATE Product_Warehouse SET IdWarehouse=@idWarehouse, IdProduct=@idProduct, IdOrder=@idOrder," +
            "Amount=@amount, Price=@price, CreatedAt=@createdAt WHERE IdProductWarehouse=@id";
        cmd.Parameters.AddWithValue("@idWarehouse", dto.IdWarehouse);
        cmd.Parameters.AddWithValue("@idProduct", dto.IdProduct);
        cmd.Parameters.AddWithValue("@idOrder", dto.IdOrder);
        cmd.Parameters.AddWithValue("@amount", dto.Amount);
        cmd.Parameters.AddWithValue("@price", dto.Price);
        cmd.Parameters.AddWithValue("@createdAt", dto.CreatedAt);
        cmd.Parameters.AddWithValue("@id", IdProductWarehouse);

        var affectedRows = await cmd.ExecuteNonQueryAsync();
        return affectedRows == 1;
    }

    public async Task<bool> DeleteProductWarehouse(int IdProductWarehouse)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE Product_Warehouse WHERE IdProductWarehouse=@id";
        cmd.Parameters.AddWithValue("@id", IdProductWarehouse);

        var affectedRows = await cmd.ExecuteNonQueryAsync();
        return affectedRows == 1;
    }
}