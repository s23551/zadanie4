namespace zadanie4.Model;

public interface IWarehouseService
{
    Task<IEnumerable<Warehouse>> GetWarehouses();
    Task<Warehouse> GetWarehouse(int IdWarehouse);
    bool AddWarehouse(WarehouseDTO dto);
    bool UpdateWarehouse(int IdWarehouse, WarehouseDTO dto);
    bool DeleteWarehouse(int IdWarehouse);
}