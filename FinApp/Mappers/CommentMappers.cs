using FinApp.DTOs.Comment;
using FinApp.DTOs.Comments;
using FinApp.Models;

namespace FinApp.Mappers;

public static class CommentMappers
{
    public static CommentDto ToCommentDto(this Comment comment)
    {
        return new CommentDto
        {
            Id = comment.Id,
            Title = comment.Title,
            Content = comment.Content,
            CreatedOn = comment.CreatedOn,
            StockId = comment.StockId
        };
    }

    public static Comment ToCommentDtoFromCreate(this CreateCommentDto commentDto, Guid stockId)
    {
        return new Comment()
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
            StockId = stockId
        };
    }

    public static Comment ToCommentDtoFromUpdate(this UpdateCommentDto createCommentDto, Guid stockId)
    {
        return new Comment()
        {
            Title = createCommentDto.Title,
            Content = createCommentDto.Content,
            StockId = stockId
        };
    }
}