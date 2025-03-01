using FinApp.Data;
using FinApp.DTOs.Comment;
using FinApp.Interfaces.Comment;
using FinApp.Mappers.Comment;
using FinApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Repository.CommentRepository;

public class CommentRepository(AppDBContext dbContext) : ICommentRepository
{
    public async Task<List<CommentModel>> GetAllCommentsAsync()
    {
        var comments = await dbContext.Comments.Select(c => c.ToCommentDto()).ToListAsync();
        return comments.Select(dto => dto.ToCommentModel()).ToList();
    }

    public async Task<CommentModel?> GetCommentByIdAsync(Guid id)
    {
        var commentModel = await dbContext.Comments.FindAsync(id);
        var commentDto = commentModel?.ToCommentDto();
        return commentDto?.ToCommentModel();
    }

    public async Task<CommentModel> CreateCommentAsync(CreateCommentDto createCommentDto)
    {
        var newComment = createCommentDto.ToCommentDtoFromCreateCommentModel();
        await dbContext.AddAsync(newComment);
        return newComment;

    }

    public async Task<CommentModel?> UpdateCommentByAsync(Guid id, UpdateCommentDto updateCommentDto)
    {
        var comment = await dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (comment == null)
        {
            return null;
        }
        
        comment.Title = updateCommentDto.Title;
        comment.Content = updateCommentDto.Content;
        comment.CreatedOn = updateCommentDto.CreatedOn;
        comment.StockId = updateCommentDto.StockId;
        comment.StockModel = updateCommentDto.StockModel;

        await dbContext.SaveChangesAsync();
        return comment;
    }

    public async Task<CommentModel?> DeleteCommentByAsync(Guid id)
    {
        var comment = await dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (comment == null)
        {
            return null;
        }

        dbContext.Remove(comment);
        await dbContext.SaveChangesAsync();
        return comment;
    }
}