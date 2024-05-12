using System.ComponentModel.DataAnnotations;
using zadanie4.Model;

namespace zadanie4.zadanie4;

public class Assignment
{
    [Required]
    public int IdProduct { get; set; }
    [Required]
    public int IdWarehouse { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage=Messages.ERR_LESSER_THAN_ONE)]
    public int Amount { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
}