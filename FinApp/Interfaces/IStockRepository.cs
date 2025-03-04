using FinApp.DTOs.Stock;
using FinApp.DTOs.Stocks;

namespace FinApp.Interfaces;

public interface IStockRepository
{
    Task<List<Models.Stock>> GetAllStocksAsync();
    Task<Models.Stock?> GetStockByIdAsync(Guid id);
    Task<Models.Stock> CreateStockAsync(CreateStockRequestDto createStockRequestDto);
    Task<Models.Stock?> UpdateStockByIdAsync(Guid id, UpdateStockRequestDto updateStockRequestDto);
    Task<Models.Stock?> DeleteStockByIdAsync(Guid id);
    
    Task<bool> StockExists(Guid id);
}