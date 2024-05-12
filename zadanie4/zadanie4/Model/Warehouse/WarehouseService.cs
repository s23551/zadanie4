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

    public async Task<Warehouse?> GetWarehouse(int IdWarehouse)
    {
        return await _warehouseRepository.GetWarehouse(IdWarehouse);
    }

    public async Task<bool> AddWarehouse(WarehouseDTO dto)
    {
        return await _warehouseRepository.AddWarehouse(dto);
    }

    public async Task<bool> UpdateWarehouse(int IdWarehouse, WarehouseDTO dto)
    {
        return await _warehouseRepository.UpdateWarehouse(IdWarehouse, dto);
    }

    public async Task<bool> DeleteWarehouse(int IdWarehouse)
    {
        return await _warehouseRepository.DeleteWarehouse(IdWarehouse);
    }
}