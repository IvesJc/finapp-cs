using FinApp.Data;
using FinApp.DTOs.Stock;
using FinApp.Mappers.Stock;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FinApp.Controllers;

[Route("api/stock")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly AppDBContext _context;

    public StockController(AppDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllStocks()
    {
        var stocks = _context.Stocks.ToList().Select((s) => s.ToStockDto());

        return Ok(stocks);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetStockById(Guid id)
    {
        var stock = _context.Stocks.Find(id);
        if (stock == null)
        {
            return NotFound();
        }

        var stockDto = stock.ToStockDto();
        return Ok(stockDto);
    }

    [HttpPost]
    public IActionResult CreateStock([FromBody] CreateStockRequestDto stockDto)
    {
        var stockModel = stockDto.ToStockFromCreateDto();
        _context.Stocks.Add(stockModel);
        _context.SaveChanges(); 

        return CreatedAtAction(nameof(GetStockById), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateStock(Guid id, [FromBody] UpdateStockRequestDto updateStockRequestDto)
    {
         var stockModel = _context.Stocks.FirstOrDefault(s => s.Id == id);
         if (stockModel == null)
         {
             return NotFound();
         }
         stockModel.Symbol = updateStockRequestDto.Symbol;
         stockModel.CompanyName = updateStockRequestDto.CompanyName;
         stockModel.Industry = updateStockRequestDto.Industry;
         stockModel.Purchase  = updateStockRequestDto.Purchase;
         stockModel.LastDiv = updateStockRequestDto.LastDiv;
         stockModel.MarketCap = updateStockRequestDto.MarketCap;

         _context.SaveChanges();
         return Ok(stockModel.ToStockDto());
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteStock(Guid id)
    {
        var stockModel = _context.Stocks.FirstOrDefault(s => s.Id == id);
        if (stockModel == null)
        {
            return NotFound();
        }

        _context.Stocks.Remove(stockModel);
        _context.SaveChanges();

        return NoContent();
    }
}