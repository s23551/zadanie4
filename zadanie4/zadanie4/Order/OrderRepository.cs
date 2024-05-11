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
        cmd.CommandText = "SELECT IdOrder, IdProduct, Amount, CreatedAt, FulfilledAt FROM Order";

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
                FulfilledAt = (DateTime)dr["FulfilledAt"]
            };
            orders.Add(order);
        }

        return orders;
    }

    public async Task<Order> GetOrder(int IdOrder)
    {
        throw new NotImplementedException();
    }

    public bool AddOrder(OrderDTO dto)
    {
        throw new NotImplementedException();
    }

    public bool UpdateOrder(int IdOrder, OrderDTO dto)
    {
        throw new NotImplementedException();
    }

    public bool DeleteOrder(int IdOrder)
    {
        throw new NotImplementedException();
    }
}