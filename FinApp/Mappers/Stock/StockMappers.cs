using FinApp.DTOs.Stock;
using FinApp.Models;

namespace FinApp.Mappers.Stock;

public static class StockMappers
{
    public static StockDto ToStockDto(this StockModel stockModel)
    {
        return new StockDto()
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            MarketCap = stockModel.MarketCap,
            Purchase = stockModel.Purchase,
            LastDiv = stockModel.LastDiv,
            Industry = stockModel.Industry,
        };
    }

    public static StockModel ToStockModel(this StockDto stockDto)
    {
        return new StockModel()
        {
            Id = stockDto.Id,
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            MarketCap = stockDto.MarketCap,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
        };
    }

    public static StockModel ToStockFromCreateDto(this CreateStockRequestDto stockDto)
    {
        return new StockModel()
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