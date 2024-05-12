namespace zadanie4.Model;

public interface IWarehouseRepository
{
    Task<IEnumerable<Warehouse>> GetWarehouses();
    Task<Warehouse?> GetWarehouse(int IdWarehouse);
    Task<bool> AdWarehouse(WarehouseDTO dto);
    Task<bool> UpdateWarehouse(int IdWarehouse, WarehouseDTO dto);
    Task<bool> DeleteWarehouse(int IdWarehouse);


}