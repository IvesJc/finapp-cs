using System;
using FinApp.Models;

namespace FinApp.DTOs.Comment;

public class CommentDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Title { get; set; } = string.Empty;
    
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    
    public Guid? StockId { get; set; }
}