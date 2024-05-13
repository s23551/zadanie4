using zadanie4.Model;

namespace zadanie4.zadanie4;

public interface IAssignmentRepository
{
    Task<bool> FulfillAssignment(Assignment dto, Order order, decimal price);
    Task<bool> FulfillAssignmentProcedure(Assignment dto, Order order, decimal price);
}