namespace zadanie4.Model;

public class ProductWarehouseService : IProductWarehouseService
{
    private readonly IProductWarehouseRepository _productWarehouseRepository;

    public ProductWarehouseService(IProductWarehouseRepository productWarehouseRepository)
    {
        _productWarehouseRepository = productWarehouseRepository;
    }

    public async Task<IEnumerable<ProductWarehouse>> GetProductWarehouses()
    {
        return await _productWarehouseRepository.GetProductWarehouses();
    }

    public async Task<ProductWarehouse?> GetProductWarehouse(int IdProductWarehouse)
    {
        return await _productWarehouseRepository.GetProductWarehouse(IdProductWarehouse);
    }

    public async Task<ProductWarehouse?> GetProductWarehouseByIdOrder(int IdOrder)
    {
        return await _productWarehouseRepository.GetProductWarehouseByIdOrder(IdOrder);
    }

    public async Task<bool> AddProductWarehouse(ProductWarehouseDTO dto)
    {
        return await _productWarehouseRepository.AddProductWarehouse(dto);
    }

    public async Task<bool> UpdateProductWarehouse(int IdProductWarehouse, ProductWarehouseDTO dto)
    {
        return await _productWarehouseRepository.UpdateProductWarehouse(IdProductWarehouse, dto);
    }

    public async Task<bool> DeleteProductWarehouse(int IdProductWarehouse)
    {
        return await _productWarehouseRepository.DeleteProductWarehouse(IdProductWarehouse);
    }
}