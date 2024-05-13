using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using zadanie4.Model;

namespace zadanie4.zadanie4;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly IConfiguration _configuration;

    public AssignmentRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<bool> FulfillAssignment(Assignment dto, Order order, decimal price)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        var tran = await con.BeginTransactionAsync();
        cmd.Transaction = (SqlTransaction)tran;

        try
        {
            cmd.CommandText = "UPDATE [Order] SET FulfilledAt=@fulfilledAt WHERE IdOrder=@id";
            cmd.Parameters.AddWithValue("@fulfilledAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@id", order.IdOrder);
            await cmd.ExecuteNonQueryAsync();

            cmd.Parameters.Clear();
            cmd.CommandText =
                "INSERT INTO Product_Warehouse (IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) " +
                "VALUES (@idWarehouse, @idProduct, @idOrder, @amount, @price, @createdAt)";
            cmd.Parameters.AddWithValue("@idWarehouse", dto.IdWarehouse);
            cmd.Parameters.AddWithValue("@idProduct", dto.IdProduct);
            cmd.Parameters.AddWithValue("@idOrder", order.IdOrder);
            cmd.Parameters.AddWithValue("@amount", order.Amount);
            cmd.Parameters.AddWithValue("@price", order.Amount * price);
            cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
            await cmd.ExecuteNonQueryAsync();

            await tran.CommitAsync();
            return true;
        }
        catch (SqlException e)
        {
            await tran.RollbackAsync();
        }
        catch (Exception e)
        {
            await tran.RollbackAsync();
        }

        return false;
    }
}