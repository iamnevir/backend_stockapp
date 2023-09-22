using StockAppWebApi.Models;
using StockAppWebApi.Repositories;

namespace StockAppWebApi.Services;

public class StockService:IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }
    public async Task<Stock?> GetStockById(int id)
    {
        return await _stockRepository.GetStockById(id);
    }

    public async Task<Stock?> GetStockByCompanyName(string companyName)
    {
        return await _stockRepository.GetStockByCompanyName(companyName);
    }
}
