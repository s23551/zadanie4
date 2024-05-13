namespace zadanie4.Model;

public interface IProductWarehouseService
{
    Task<IEnumerable<ProductWarehouse>> GetProductWarehouses();
    Task<ProductWarehouse?> GetProductWarehouse(int IdProductWarehouse);
    Task<ProductWarehouse?> GetProductWarehouseByIdOrder(int IdOrder);
    Task<bool> AddProductWarehouse(ProductWarehouseDTO dto);
    Task<bool> UpdateProductWarehouse(int IdProductWarehouse, ProductWarehouseDTO dto);
    Task<bool> DeleteProductWarehouse(int IdProductWarehouse);

}