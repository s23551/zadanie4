namespace zadanie4.Model;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrders();
    Task<Order> GetOrder(int IdOrder);
    bool AddOrder(OrderDTO dto);
    bool UpdateOrder(int IdOrder, OrderDTO dto);
    bool DeleteOrder(int IdOrder);
}