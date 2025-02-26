using FinApp.Models;

namespace FinApp.Interfaces.Comment;

public interface ICommentRepository
{
    Task<List<CommentModel>> GetAllCommentsAsync();
}