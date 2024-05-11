using System.ComponentModel.DataAnnotations;

namespace zadanie4.Model;

public class Product_Warehouse
{
    public int IdProductWarehouse { get; set; }
    
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = Messages.ERR_NEGATIVE_VALUE)]
    public int IdWarehouse { get; set; }
    
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = Messages.ERR_NEGATIVE_VALUE)]
    public int IdProduct { get; set; }
    
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = Messages.ERR_NEGATIVE_VALUE)]
    public int IdOrder { get; set; }
    
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = Messages.ERR_NEGATIVE_VALUE)]
    public int Amount { get; set; }
    
    [Required]
    [Range(0.0, (double) decimal.MaxValue, ErrorMessage = Messages.ERR_NEGATIVE_VALUE)]
    public decimal Price { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
}