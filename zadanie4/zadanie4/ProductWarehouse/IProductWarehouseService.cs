namespace zadanie4.Model;

public interface IProductWarehouseService
{
    Task<IEnumerable<ProductWarehouse>> GetProductWarehouses();
    Task<ProductWarehouse> GetProductWarehouse(int IdProductWarehouse);
    bool AddProductWarehouse(ProductWarehouseDTO dto);
    bool UpdateProductWarehouse(int IdProductWarehouse, ProductWarehouseDTO dto);
    bool DeleteProductWarehouse(int IdProductWarehouse);

}