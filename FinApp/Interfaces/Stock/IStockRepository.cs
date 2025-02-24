using FinApp.DTOs.Stock;
using FinApp.Models;

namespace FinApp.Interfaces.Stock;

public interface IStockRepository
{
    Task<List<StockModel>> GetAllStocksAsync();
    Task<StockModel?> GetStockByIdAsync(Guid id);
    Task<StockModel> CreateStockAsync(CreateStockRequestDto createStockRequestDto);
    Task<StockModel?> UpdateStockByIdAsync(Guid id, UpdateStockRequestDto updateStockRequestDto);
    Task<StockModel?> DeleteStockByIdAsync(Guid id);
}