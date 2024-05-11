using System.ComponentModel.DataAnnotations;

namespace zadanie4.Model;

public class WarehouseDTO
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Address { get; set; }
}