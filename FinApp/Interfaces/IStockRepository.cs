using FinApp.DTOs.Stocks;
using FinApp.Helpers;
using FinApp.Models;

namespace FinApp.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllStocksAsync(QueryObjects queryObjects);
    Task<Stock?> GetStockByIdAsync(Guid id);
    Task<Stock> CreateStockAsync(CreateStockRequestDto createStockRequestDto);
    Task<Stock?> UpdateStockByIdAsync(Guid id, UpdateStockRequestDto updateStockRequestDto);
    Task<Stock?> DeleteStockByIdAsync(Guid id);
    
    Task<bool> StockExists(Guid id);
}