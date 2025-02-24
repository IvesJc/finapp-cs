using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinApp.Models;

[Table("tb_comment")]
public class CommentModel
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column(TypeName = "varchar(50)")]
    public string Title { get; set; } = string.Empty;
    
    [Column(TypeName = "varchar(100)")]
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    
    public int? StockId { get; set; }
    public StockModel StockModel { get; set; }
}