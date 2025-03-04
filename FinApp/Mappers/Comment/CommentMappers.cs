using FinApp.DTOs.Comment;
using FinApp.Models;

namespace FinApp.Mappers.Comment;

public static class CommentMappers
{
    public static CommentDto ToCommentDto(this Models.Comment comment)
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

    public static Models.Comment ToCommentDtoFromCreate(this CreateCommentDto commentDto, Guid stockId)
    {
        return new Models.Comment()
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
            StockId = stockId
        };
    }

    public static Models.Comment ToCommentDtoFromUpdate(this UpdateCommentDto createCommentDto, Guid stockId)
    {
        return new Models.Comment()
        {
            Title = createCommentDto.Title,
            Content = createCommentDto.Content,
            StockId = stockId
        };
    }
}