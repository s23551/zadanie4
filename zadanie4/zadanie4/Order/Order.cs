using System.ComponentModel.DataAnnotations;

namespace zadanie4.Model;

public class Order
{
    public int IdOrder { get; set; }
    
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = Messages.ERR_NEGATIVE_VALUE)]
    public int IdProduct { get; set; }
    
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = Messages.ERR_NEGATIVE_VALUE)]
    public int Amount { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    public DateTime FulfilledAd { get; set; }
}