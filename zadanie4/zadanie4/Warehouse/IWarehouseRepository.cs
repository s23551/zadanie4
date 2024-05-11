namespace zadanie4.Model;

public interface IWarehouseRepository
{
    Task<IEnumerable<Warehouse>> GetWarehouses();
    Task<Warehouse> GetWarehouse(int IdWarehouse);
    bool AdWarehouse(WarehouseDTO dto);
    bool UpdateWarehouse(int IdWarehouse, WarehouseDTO dto);
    bool DeleteWarehouse(int IdWarehouse);


}