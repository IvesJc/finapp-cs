using FinApp.DTOs.Stock;
using FinApp.Mappers.Comment;
using FinApp.Models;

namespace FinApp.Mappers.Stock;

public static class StockMappers
{
    public static StockDto ToStockDto(this Models.Stock stock)
    {
        return new StockDto()
        {
            Id = stock.Id,
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            MarketCap = stock.MarketCap,
            Purchase = stock.Purchase,
            LastDiv = stock.LastDiv,
            Industry = stock.Industry,
            Comments = stock.Comments.Select(c => c.ToCommentDto()).ToList(),
        };
    }

    public static Models.Stock ToStockModel(this StockDto stockDto)
    {
        return new Models.Stock()
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            MarketCap = stockDto.MarketCap,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
        };
    }

    public static Models.Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
    {
        return new Models.Stock()
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            MarketCap = stockDto.MarketCap,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
        };
    }
}