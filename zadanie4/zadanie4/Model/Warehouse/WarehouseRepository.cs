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

    public async Task<Warehouse?> GetWarehouse(int IdWarehouse)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdWarehouse, Name, Address FROM Warehouse WHERE IdWarehouse=@id";
        cmd.Parameters.AddWithValue("@id", IdWarehouse);

        var dr = await cmd.ExecuteReaderAsync();
        if (await dr.ReadAsync())
        {
            var warehouse = new Warehouse
            {
                IdWarehouse = (int)dr["IdWarehouse"],
                Name = dr["Name"].ToString(),
                Address = dr["Address"].ToString()
            };
            return warehouse;
        }

        return null;
    }

    public async Task<bool> AddWarehouse(WarehouseDTO dto)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Warehouse (Name, Address) VALUES (@name, @address)";
        cmd.Parameters.AddWithValue("@name", dto.Name);
        cmd.Parameters.AddWithValue("@address", dto.Address);

        var affectedRows = await cmd.ExecuteNonQueryAsync();
        return affectedRows == 1;
    }

    public async Task<bool> UpdateWarehouse(int IdWarehouse, WarehouseDTO dto)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Warehouse SET Name=@name, Address=@address WHERE IdWarehouse=@id";
        cmd.Parameters.AddWithValue("@name", dto.Name);
        cmd.Parameters.AddWithValue("@address", dto.Address);
        cmd.Parameters.AddWithValue("@id", IdWarehouse);

        var affectedRows = await cmd.ExecuteNonQueryAsync();
        return affectedRows == 1;
    }

    public async Task<bool> DeleteWarehouse(int IdWarehouse)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE Warehouse WHERE IdWarehouse=@id";
        cmd.Parameters.AddWithValue("@id", IdWarehouse);

        var affectedRows = await cmd.ExecuteNonQueryAsync();
        return affectedRows == 1;
    }
}