using System.ComponentModel.DataAnnotations;

namespace zadanie4.Model;

public class Warehouse
{
    public int IdWarehouse { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength]
    public string Address { get; set; }
}