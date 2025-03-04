using FinApp.DTOs.Comment;
using FinApp.Models;

namespace FinApp.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllCommentsAsync();
    Task<Comment?> GetCommentByIdAsync(Guid id);
    Task<Comment> CreateCommentAsync(Comment commentModel);
    Task<Comment?> UpdateCommentByAsync(Guid id, UpdateCommentDto updateCommentDto);
    Task<Comment?> DeleteCommentByAsync(Guid id);
}