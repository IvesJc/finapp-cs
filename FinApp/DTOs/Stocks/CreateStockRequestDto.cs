using System.ComponentModel.DataAnnotations;

namespace FinApp.DTOs.Stocks;

public class CreateStockRequestDto
{
    [Required]
    [MaxLength(10, ErrorMessage = "Symbol Name cannot be longer than 10 characters.")]
    public string Symbol { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(10, ErrorMessage = "CompanyName cannot be longer than 100 characters.")]
    public string CompanyName { get; set; } = string.Empty;
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Purchase cannot be negative.")]
    public decimal Purchase { get; set; }   
    
    [Required]
    [Range(0.001, 100)]
    public decimal LastDiv { get; set; }

    [Required]
    [MaxLength(10, ErrorMessage = "Industry Name cannot be longer than 10 characters.")]
    public string Industry { get; set; } = string.Empty;
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "MarketCap cannot be negative.")]
    public long MarketCap { get; set; }
}