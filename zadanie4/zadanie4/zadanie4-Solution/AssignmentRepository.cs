using System.Data;
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
            cmd.Connection = con;
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

    public async Task<bool> FulfillAssignmentProcedure(Assignment dto, Order order, decimal Price)
    {
        await using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        await con.OpenAsync();

        await using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "AddProductToWarehouse";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@IdProduct", SqlDbType.Int).Value = order.IdProduct;
        cmd.Parameters.Add("@IdWarehouse", SqlDbType.Int).Value = dto.IdWarehouse;
        cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = order.Amount;
        cmd.Parameters.Add("@CreatedAt", SqlDbType.DateTime).Value = DateTime.Now;

        var affectedRows = await cmd.ExecuteNonQueryAsync();
        return affectedRows == 1;
    }
}