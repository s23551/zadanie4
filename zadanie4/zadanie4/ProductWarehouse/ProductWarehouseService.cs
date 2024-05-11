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

    public async Task<ProductWarehouse> GetProductWarehouse(int IdProductWarehouse)
    {
        throw new NotImplementedException();
    }

    public bool AddProductWarehouse(ProductWarehouseDTO dto)
    {
        throw new NotImplementedException();
    }

    public bool UpdateProductWarehouse(int IdProductWarehouse, ProductWarehouseDTO dto)
    {
        throw new NotImplementedException();
    }

    public bool DeleteProductWarehouse(int IdProductWarehouse)
    {
        throw new NotImplementedException();
    }
}