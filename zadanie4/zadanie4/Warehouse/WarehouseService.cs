namespace zadanie4.Model;

public class WarehouseService : IWarehouseService
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehouseService(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public async Task<IEnumerable<Warehouse>> GetWarehouses()
    {
        return await _warehouseRepository.GetWarehouses();
    }

    public async Task<Warehouse> GetWarehouse(int IdWarehouse)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddWarehouse(WarehouseDTO dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateWarehouse(int IdWarehouse, WarehouseDTO dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteWarehouse(int IdWarehouse)
    {
        throw new NotImplementedException();
    }
}