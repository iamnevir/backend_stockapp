using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories;

public interface ICoveredWarrantRepository
{

    Task<List<CoveredWarrant>> GetCoveredWarrantsByStockId(int stockId);
}
