namespace zadanie4.Model;

public interface IWarehouseService
{
    Task<IEnumerable<Warehouse>> GetWarehouses();
    Task<Warehouse?> GetWarehouse(int IdWarehouse);
    Task<bool> AddWarehouse(WarehouseDTO dto);
    Task<bool> UpdateWarehouse(int IdWarehouse, WarehouseDTO dto);
    Task<bool> DeleteWarehouse(int IdWarehouse);
}