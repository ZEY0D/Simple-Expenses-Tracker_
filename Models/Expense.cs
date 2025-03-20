using System;

using System.ComponentModel.DataAnnotations;
namespace efinancee.Models;

public class Expense
{
    public int ID { get; set; } 
    

    [Range(0.01 , double.MaxValue , ErrorMessage = "Invalid Amount")] 
    
    public Double Amount { get; set; }
    
    [StringLength(20)] 
    public required string Category { get; set; }

    
    public string? Description { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}
