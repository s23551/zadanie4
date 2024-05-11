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

    public async Task<ProductWarehouse> GetProductWarehouse(int IdProductWarehouse)
    {
        throw new NotImplementedException();
    }

    public bool AddProductWarehouse(ProductWarehouseDTO dto)
    {
        throw new NotImplementedException();
    }

    public bool UpdateProductWarehouse(int IdProductWarehouse, ProductWarehouseDTO dto)
    {
        throw new NotImplementedException();
    }

    public bool DeleteProductWarehouse(int IdProductWarehouse)
    {
        throw new NotImplementedException();
    }
}