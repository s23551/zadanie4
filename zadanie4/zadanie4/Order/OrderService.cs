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

    public async Task<Order?> GetOrder(int IdOrder)
    {
        return await _orderRepository.GetOrder(IdOrder);
    }

    public async Task<bool> AddOrder(OrderDTO dto)
    {
        return await _orderRepository.AddOrder(dto);
    }

    public async Task<bool> UpdateOrder(int IdOrder, OrderDTO dto)
    {
        return await _orderRepository.UpdateOrder(IdOrder, dto);
    }

    public async Task<bool> DeleteOrder(int IdOrder)
    {
        return await _orderRepository.DeleteOrder(IdOrder);
    }
}