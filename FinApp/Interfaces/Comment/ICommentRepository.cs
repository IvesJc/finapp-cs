using FinApp.DTOs.Comment;
using FinApp.Models;

namespace FinApp.Interfaces.Comment;

public interface ICommentRepository
{
    Task<List<CommentModel>> GetAllCommentsAsync();
    Task<CommentModel?> GetCommentByIdAsync(Guid id);
    Task<CommentModel> CreateCommentAsync(CreateCommentDto createCommentDto);
    Task<CommentModel?> UpdateCommentByAsync(Guid id, UpdateCommentDto updateCommentDto);
    Task<CommentModel?> DeleteCommentByAsync(Guid id);
}