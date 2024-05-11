using System.ComponentModel.DataAnnotations;

namespace zadanie4.Model;

public class ProductDTO
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    
    [Required]
    [Range(0.0, (double) decimal.MaxValue, ErrorMessage = Messages.ERR_NEGATIVE_VALUE)]
    public decimal Price { get; set; }
}