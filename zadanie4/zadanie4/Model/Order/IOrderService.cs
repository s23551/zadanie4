namespace zadanie4.Model;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrders();
    Task<Order?> GetOrder(int IdOrder);
    Task<Order?> GetOrderByIdProduct(int IdProduct);
    Task<bool> AddOrder(OrderDTO dto);
    Task<bool> UpdateOrder(int IdOrder, OrderDTO dto);
    Task<bool> DeleteOrder(int IdOrder);
}