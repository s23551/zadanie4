using System.Data.SqlClient;

namespace zadanie4.Model;

public class OrderRepository : IOrderRepository
{
    private readonly IConfiguration _configuration;

    public OrderRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<Order>> GetOrders()
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdOrder, IdProduct, Amount, CreatedAt, FulfilledAt FROM [Order]";

        var dr = await cmd.ExecuteReaderAsync();
        var orders = new List<Order>();

        while (await dr.ReadAsync())
        {
            var order = new Order
            {
                IdOrder = (int)dr["IdOrder"],
                IdProduct = (int)dr["IdProduct"],
                Amount = (int)dr["Amount"],
                CreatedAt = (DateTime)dr["CreatedAt"],
                FulfilledAt = await dr.IsDBNullAsync(dr.GetOrdinal("FulfilledAt")) ? (DateTime?) null : (DateTime) dr["FulfilledAt"]
            };
            orders.Add(order);
        }

        return orders;
    }

    public async Task<Order?> GetOrder(int IdOrder)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdOrder, IdProduct, Amount, CreatedAt, FulfilledAt FROM [Order] WHERE IdOrder=@id";
        cmd.Parameters.AddWithValue("@id", IdOrder);

        var dr = await cmd.ExecuteReaderAsync();

        if (await dr.ReadAsync())
        {
            var order = new Order
            {
                IdOrder = (int)dr["IdOrder"],
                IdProduct = (int)dr["IdProduct"],
                Amount = (int)dr["Amount"],
                CreatedAt = (DateTime)dr["CreatedAt"],
                FulfilledAt = await dr.IsDBNullAsync(dr.GetOrdinal("FulfilledAt"))
                    ? (DateTime?)null
                    : (DateTime)dr["FulfilledAt"]
            };
            return order;
        }

        return null;
    }

    public async Task<bool> AddOrder(OrderDTO dto)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        if (!dto.FulfilledAt.HasValue)
        {
            cmd.CommandText =
                "INSERT INTO [Order] (IdProduct, Amount, CreatedAt) VALUES(@idProduct, @amount, @createdAt)";
            
        }
        else
        {
            cmd.CommandText =
                "INSERT INTO [Order] (IdProduct, Amount, CreatedAt, FulfilledAt) " +
                "VALUES (@idProduct, @amount, @createdAt, @fulfilledAt)"; 
            cmd.Parameters.AddWithValue("@fulfilledAt", dto.FulfilledAt); 
        }
        
        cmd.Parameters.AddWithValue("@idProduct", dto.IdProduct);
        cmd.Parameters.AddWithValue("@amount", dto.Amount);
        cmd.Parameters.AddWithValue("@createdAt", dto.CreatedAt);
       

        var affectedRows = await cmd.ExecuteNonQueryAsync();
        return affectedRows == 1;
    }

    public async Task<bool> UpdateOrder(int IdOrder, OrderDTO dto)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        if (dto.FulfilledAt.HasValue)
        {
            cmd.CommandText =
                "UPDATE [Order] SET IdProduct=@idProduct, Amount=@amount, CreatedAt=@createdAt, FulfilledAt=@fulfilledAt WHERE IdOrder=@id";
            cmd.Parameters.AddWithValue("@fulfilledAt", dto.FulfilledAt);
        }
        else
        {
            cmd.CommandText =
                "UPDATE [Order] SET IdProduct=@idProduct, Amount=@amount, CreatedAt=@createdAt WHERE IdOrder=@id";
        }
        cmd.Parameters.AddWithValue("@idProduct", dto.IdProduct);
        cmd.Parameters.AddWithValue("@amount", dto.Amount);
        cmd.Parameters.AddWithValue("@createdAt", dto.CreatedAt);
        cmd.Parameters.AddWithValue("@id", IdOrder);

        var affectedRows = await cmd.ExecuteNonQueryAsync();
        return affectedRows == 1;
    }

    public async Task<bool> DeleteOrder(int IdOrder)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM [Order] WHERE IdOrder=@id";
        cmd.Parameters.AddWithValue("@id", IdOrder);

        var affectedRows = await cmd.ExecuteNonQueryAsync();
        return affectedRows == 1;
    }
}