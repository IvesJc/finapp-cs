using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinApp.Models;

[Table("tb_stock")]
public class StockModel
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column(TypeName = "varchar(10)")]
    public string Symbol { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar(50)")]
    public string CompanyName { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Purchase { get; set; }   
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal LastDiv { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Industry { get; set; } = string.Empty;
    public long MarketCap { get; set; }

    [Column(TypeName = "varchar(100)")]
    public List<CommentModel> Comments { get; set; } = [];
}