using zadanie4.Model;

namespace zadanie4.zadanie4;

public class AssignmentService : IAssignmentService
{
    private readonly IOrderService _orderService;
    private readonly IWarehouseService _warehouseService;
    private readonly IProductService _productService;
    private readonly IProductWarehouseService _productWarehouseService;

    public AssignmentService(IOrderService orderService, IWarehouseService warehouseService, 
        IProductService productService, IProductWarehouseService productWarehouseService)
    {
        _orderService = orderService;
        _warehouseService = warehouseService;
        _productService = productService;
        _productWarehouseService = productWarehouseService;
    }

    public async Task<bool> AddAssignment(Assignment dto)
    {
        var product = await _productService.GetProduct(dto.IdProduct);
        var warehouse = await _warehouseService.GetWarehouse(dto.IdWarehouse);
        if (product == null || warehouse == null)
        {
            return false;
        }

        var order = await _orderService.GetOrderByIdProduct(dto.IdProduct);
        var validatedOrder = order != null && 
                             order.Amount == dto.Amount && order.CreatedAt < dto.CreatedAt;
        if (!validatedOrder)
        {
            return false;
        }

        var fulfilledOrder = (await _productWarehouseService.GetProductWarehouseByIdOrder(order.IdOrder)) == null;
        if (fulfilledOrder)
        {
            return false;
        }
        
        
        // TODO
        return true;
    }
}