using FinApp.DTOs.Comment;
using FinApp.DTOs.Comments;
using FinApp.Interfaces;
using FinApp.Interfaces.Stock;
using FinApp.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController(ICommentRepository commentRepository, IStockRepository stockRepository) : ControllerBase
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

    [HttpPost("{stockId:guid}")]
    public async Task<IActionResult> CreateComment([FromRoute] Guid stockId, CreateCommentDto commentDto)
    {
        if (!await stockRepository.StockExists(stockId))
        {
            return BadRequest("Stock doesn't exist");
        }
        
        var commentModel = commentDto.ToCommentDtoFromCreate(stockId); 
        await commentRepository.CreateCommentAsync(commentModel);
        return CreatedAtAction(nameof(GetCommentById), new {id = commentModel.Id}, commentModel.ToCommentDto());
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
        var comment = await commentRepository.DeleteCommentByAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}