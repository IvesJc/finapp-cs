using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinApp.Data;
using FinApp.DTOs.Stock;
using FinApp.Interfaces.Stock;
using FinApp.Mappers.Stock;
using FinApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Repository.Stock;

public class StockRepository(AppDBContext context) : IStockRepository
{
    public async Task<List<Models.Stock>> GetAllStocksAsync()
    {
        return await context.Stocks.Include(c => c.Comments).ToListAsync();
    }

    public async Task<Models.Stock?> GetStockByIdAsync(Guid id)
    {
        var stockModel = await context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(stockId => stockId.Id == id);
        var stockDto = stockModel?.ToStockDto();
        return stockDto?.ToStockModel();
    }

    public async Task<Models.Stock> CreateStockAsync(CreateStockRequestDto createStockRequestDto)
    {
        var stockModel = createStockRequestDto.ToStockFromCreateDto();
        await context.Stocks.AddAsync(stockModel);
        await context.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Models.Stock?> UpdateStockByIdAsync(Guid id, UpdateStockRequestDto updateStockRequestDto)
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

    public async Task<Models.Stock?> DeleteStockByIdAsync(Guid id)
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

    public async Task<bool> StockExists(Guid id)
    {
        return await context.Stocks.AnyAsync(stock => stock.Id == id);
    }
}