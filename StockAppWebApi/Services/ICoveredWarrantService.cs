using StockAppWebApi.Models;

namespace StockAppWebApi.Services;

public interface ICoveredWarrantService
{

    Task<List<CoveredWarrant>> GetCoveredWarrantsByStockId(int stockId);
}
