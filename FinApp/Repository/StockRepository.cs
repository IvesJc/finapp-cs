using FinApp.Data;
using FinApp.DTOs.Stocks;
using FinApp.Helpers;
using FinApp.Interfaces;
using FinApp.Mappers;
using FinApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Repository;

public class StockRepository(AppDBContext context) : IStockRepository
{
    public async Task<List<Stock>> GetAllStocksAsync(QueryObjects queryObjects)
    {
        var stocks = context.Stocks.Include(c => c.Comments).AsQueryable();
        if (!string.IsNullOrWhiteSpace(queryObjects.Symbol))
        {
            stocks = stocks.Where(s => s.Symbol.Contains(queryObjects.Symbol));
        }
        if (!string.IsNullOrWhiteSpace(queryObjects.CompanyName))
        {
            stocks = stocks.Where(cn => cn.CompanyName.Contains(queryObjects.CompanyName));
        }

        if (string.IsNullOrWhiteSpace(queryObjects.SortBy)) return await stocks.ToListAsync();
        if (queryObjects.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
        {
            stocks = queryObjects.IsDescending
                ? stocks.OrderByDescending(sb => sb.Symbol)
                : stocks.OrderBy(sb => sb.Symbol);
        }

        return await stocks.ToListAsync();
    }

    public async Task<Stock?> GetStockByIdAsync(Guid id)
    {
        var stockModel = await context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(stockId => stockId.Id == id);
        var stockDto = stockModel?.ToStockDto();
        return stockDto?.ToStockModel();
    }

    public async Task<Stock> CreateStockAsync(CreateStockRequestDto createStockRequestDto)
    {
        var stockModel = createStockRequestDto.ToStockFromCreateDto();
        await context.Stocks.AddAsync(stockModel);
        await context.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Stock?> UpdateStockByIdAsync(Guid id, UpdateStockRequestDto updateStockRequestDto)
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

    public async Task<Stock?> DeleteStockByIdAsync(Guid id)
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