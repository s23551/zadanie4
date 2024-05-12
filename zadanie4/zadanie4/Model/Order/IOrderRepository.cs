namespace zadanie4.Model;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrders();
    Task<Order?> GetOrder(int IdOrder);
    Task<bool> AddOrder(OrderDTO dto);
    Task<bool> UpdateOrder(int IdOrder, OrderDTO dto);
    Task<bool> DeleteOrder(int IdOrder);
}