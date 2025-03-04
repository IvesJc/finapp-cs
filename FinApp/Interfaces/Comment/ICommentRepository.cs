using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinApp.DTOs.Comment;
using FinApp.Models;

namespace FinApp.Interfaces.Comment;

public interface ICommentRepository
{
    Task<List<Models.Comment>> GetAllCommentsAsync();
    Task<Models.Comment?> GetCommentByIdAsync(Guid id);
    Task<Models.Comment> CreateCommentAsync(Models.Comment commentModel);
    Task<Models.Comment?> UpdateCommentByAsync(Guid id, UpdateCommentDto updateCommentDto);
    Task<Models.Comment?> DeleteCommentByAsync(Guid id);
}