using FinApp.DTOs.Stock;
using FinApp.DTOs.Stocks;
using FinApp.Interfaces;
using FinApp.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Controllers;

[Route("api/stock")]
[ApiController]
public class StockController(IStockRepository stockRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllStocks()
    {
        var stocks = await stockRepository.GetAllStocksAsync();
        return Ok(stocks);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStockById(Guid id)
    {
        var stock = await stockRepository.GetStockByIdAsync(id);
        if (stock == null)
        {
            return NotFound();
        }
        return Ok(stock);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStock([FromBody] CreateStockRequestDto stockDto)
    {
        var stockModel = await stockRepository.CreateStockAsync(createStockRequestDto: stockDto);
        return CreatedAtAction(nameof(GetStockById), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateStock(Guid id, [FromBody] UpdateStockRequestDto updateStockRequestDto)
    {
        var updatedStock =  await stockRepository.UpdateStockByIdAsync(id: id, updateStockRequestDto: updateStockRequestDto);
        if (updatedStock == null)
        {
            return NotFound();
        }
        return Ok(updatedStock.ToStockDto());
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStock(Guid id)
    {
        var stock = await stockRepository.DeleteStockByIdAsync(id: id);
        if (stock == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}