using FinApp.DTOs.Stock;
using FinApp.Models;

namespace FinApp.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stock)
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

    public static Stock ToStockModel(this StockDto stockDto)
    {
        return new Stock()
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            MarketCap = stockDto.MarketCap,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
        };
    }

    public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
    {
        return new Stock()
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