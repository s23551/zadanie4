using System.Data.SqlClient;

namespace zadanie4.Model;

public class WarehouseRepository : IWarehouseRepository
{
    private IConfiguration _configuration;

    public WarehouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<Warehouse>> GetWarehouses()
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdWarehouse, Name, Address FROM Warehouse";

        var dr = await cmd.ExecuteReaderAsync();
        var warehouses = new List<Warehouse>();
        while (await dr.ReadAsync())
        {
            var warehouse = new Warehouse
            {
                IdWarehouse = (int)dr["IdWarehouse"],
                Name = dr["Name"].ToString(),
                Address = dr["Address"].ToString()
            };
            warehouses.Add(warehouse);
        }

        return warehouses;
    }

    public Task<Warehouse> GetWarehouse(int IdWarehouse)
    {
        throw new NotImplementedException();
    }

    public bool AdWarehouse(WarehouseDTO dto)
    {
        throw new NotImplementedException();
    }

    public bool UpdateWarehouse(int IdWarehouse, WarehouseDTO dto)
    {
        throw new NotImplementedException();
    }

    public bool DeleteWarehouse(int IdWarehouse)
    {
        throw new NotImplementedException();
    }
}