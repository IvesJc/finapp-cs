using FinApp.Models;

namespace FinApp.DTOs.Comment;

public class UpdateCommentDto
{
    public string Title { get; set; } = string.Empty;
    
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    
    public int? StockId { get; set; }
    public StockModel StockModel { get; set; }

}