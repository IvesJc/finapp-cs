using FinApp.DTOs.Comment;
using FinApp.Models;

namespace FinApp.Mappers.Comment;

public static class CommentMappers
{
    public static CommentDto ToCommentDto(this CommentModel commentModel)
    {
        return new CommentDto
        {
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            CreatedOn = commentModel.CreatedOn,
            StockModel = commentModel.StockModel,
            StockId = commentModel.StockId
        };
    }

    public static CommentModel ToCommentModel(this CommentDto commentDto)
    {
        return new CommentModel()
        {
            Id = commentDto.Id,
            Title = commentDto.Title,
            Content = commentDto.Content,
            CreatedOn = commentDto.CreatedOn,
            StockModel = commentDto.StockModel,
            StockId = commentDto.StockId
        };
    }

    public static CommentModel ToCommentDtoFromCreateCommentModel(this CreateCommentDto createCommentDto)
    {
        return new CommentModel()
        {
            Title = createCommentDto.Title,
            Content = createCommentDto.Content,
            CreatedOn = createCommentDto.CreatedOn,
            StockModel = createCommentDto.StockModel,
            StockId = createCommentDto.StockId
        };
    }
}