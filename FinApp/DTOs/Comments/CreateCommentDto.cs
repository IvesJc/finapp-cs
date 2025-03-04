using System.ComponentModel.DataAnnotations;

namespace FinApp.DTOs.Comments;

public class CreateCommentDto
{
    [Required]
    [MinLength(5, ErrorMessage = "Title must be at least 5 characters long")]
    [MaxLength(100, ErrorMessage = "Title must be no more than 100 characters")]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    [MinLength(5, ErrorMessage = "Content must be at least 5 characters long")]
    [MaxLength(500, ErrorMessage = "Content must be no more than 500 characters")]
    public string Content { get; set; } = string.Empty;
}