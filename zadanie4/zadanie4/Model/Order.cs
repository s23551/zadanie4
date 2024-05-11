using System.ComponentModel.DataAnnotations;

namespace zadanie4.Model;

public class Order
{
    public int IdOrder { get; set; }
    
    [Required]
    public int IdProduct { get; set; }
    
    [Required]
    public int Amount { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    public DateTime FulfilledAd { get; set; }
}