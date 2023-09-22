using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories;

public interface IStockRepository
{
    Task<Stock?> GetStockById(int id);
    Task<Stock?> GetStockByCompanyName(string companyName);
}
