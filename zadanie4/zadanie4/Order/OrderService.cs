namespace zadanie4.Model;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> GetOrders()
    {
        return await _orderRepository.GetOrders();
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