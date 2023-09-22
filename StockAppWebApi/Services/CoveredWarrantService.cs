using StockAppWebApi.Models;
using StockAppWebApi.Repositories;

namespace StockAppWebApi.Services;

public class CoveredWarrantService : ICoveredWarrantService
{
    readonly ICoveredWarrantRepository _coveredWarrantRepository;
    public CoveredWarrantService(ICoveredWarrantRepository coveredWarrantRepository)
    {
        _coveredWarrantRepository=coveredWarrantRepository;
    }
    public async Task<List<CoveredWarrant>> GetCoveredWarrantsByStockId(int stockId)
    {
        return await _coveredWarrantRepository.GetCoveredWarrantsByStockId(stockId);
    }
}
