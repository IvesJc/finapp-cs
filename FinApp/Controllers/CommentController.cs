using FinApp.DTOs.Comment;
using FinApp.Interfaces.Comment;
using FinApp.Mappers.Comment;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController(ICommentRepository commentRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetComments()
    {
        var comments = await commentRepository.GetAllCommentsAsync();
        return Ok(comments);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCommentById(Guid id)
    {
        var comment = await commentRepository.GetCommentByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        return Ok(comment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment(CreateCommentDto commentDto)
    {
        var comment = await commentRepository.CreateCommentAsync(commentDto);
        return CreatedAtAction(nameof(GetCommentById), new {id = comment.Id}, comment.ToCommentDto());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateComment(Guid id, UpdateCommentDto commentDto)
    {
        var comment = await commentRepository.UpdateCommentByAsync(id, commentDto);
        if (comment == null)
        {
            return NotFound();
        }

        return Ok(comment.ToCommentDto());
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        var comment = await commentRepository.GetCommentByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}