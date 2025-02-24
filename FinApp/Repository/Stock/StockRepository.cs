
using FinApp.Data;
using FinApp.DTOs.Stock;
using FinApp.Interfaces.Stock;
using FinApp.Mappers.Stock;
using FinApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Repository.Stock;

public class StockRepository(AppDBContext context) : IStockRepository
{
    public async Task<List<StockModel>> GetAllStocksAsync()
    {
        var stocks = await context.Stocks.Select(s => s.ToStockDto()).ToListAsync();

        return stocks.Select(x => x.ToStockModel()).ToList();
    }

    public async Task<StockModel?> GetStockByIdAsync(Guid id)
    {
        var stockModel = await context.Stocks.FindAsync(id);
        var stockDto = stockModel?.ToStockDto();
        return stockDto?.ToStockModel();
    }

    public async Task<StockModel> CreateStockAsync(CreateStockRequestDto createStockRequestDto)
    {
        var stockModel = createStockRequestDto.ToStockFromCreateDto();
        await context.Stocks.AddAsync(stockModel);
        await context.SaveChangesAsync();
        return stockModel;

    }

    public async Task<StockModel?> UpdateStockByIdAsync(Guid id, UpdateStockRequestDto updateStockRequestDto)
    {
        var stockModel = await context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

        if (stockModel != null)
        {
            stockModel.Symbol = updateStockRequestDto.Symbol;
            stockModel.CompanyName = updateStockRequestDto.CompanyName;
            stockModel.Industry = updateStockRequestDto.Industry;
            stockModel.Purchase = updateStockRequestDto.Purchase;
            stockModel.LastDiv = updateStockRequestDto.LastDiv;
            stockModel.MarketCap = updateStockRequestDto.MarketCap;
        }
        else
        {
            return null;
        }

        await context.SaveChangesAsync();
        return stockModel;
    }

    public async Task<StockModel?> DeleteStockByIdAsync(Guid id)
    {
        var stockModel = await context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
        if (stockModel == null)
        {
            return null;
        }

        context.Stocks.Remove(stockModel);
        await context.SaveChangesAsync();
        return stockModel;
    }
}