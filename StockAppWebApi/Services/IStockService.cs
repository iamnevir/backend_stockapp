using StockAppWebApi.Models;

namespace StockAppWebApi.Services;

public interface IStockService
{
    Task<Stock?> GetStockById(int id);
    Task<Stock?> GetStockByCompanyName(string companyName);
}
