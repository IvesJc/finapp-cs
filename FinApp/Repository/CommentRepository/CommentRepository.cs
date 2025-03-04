using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinApp.Data;
using FinApp.DTOs.Comment;
using FinApp.Interfaces.Comment;
using FinApp.Mappers.Comment;
using FinApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Repository.CommentRepository;

public class CommentRepository(AppDBContext dbContext) : ICommentRepository
{
    public async Task<List<Comment>> GetAllCommentsAsync()
    {
        return await dbContext.Comments.ToListAsync();
    }

    public async Task<Comment?> GetCommentByIdAsync(Guid id)
    {
        return await dbContext.Comments.FindAsync(id);
    }

    public async Task<Comment> CreateCommentAsync(Comment createCommentDto)
    {
        await dbContext.AddAsync(createCommentDto);
        await dbContext.SaveChangesAsync();
        return createCommentDto;
    }

    public async Task<Comment?> UpdateCommentByAsync(Guid id, UpdateCommentDto updateCommentDto)
    {
        var comment = await dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
        if (comment == null)
        {
            return null;
        }
        
        comment.Title = updateCommentDto.Title;
        comment.Content = updateCommentDto.Content;

        await dbContext.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> DeleteCommentByAsync(Guid id)
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