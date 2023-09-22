using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories;

public class CoveredWarrantRepository : ICoveredWarrantRepository
{
    readonly StockAppDbContext _dbContext;
    public CoveredWarrantRepository(StockAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<CoveredWarrant>> GetCoveredWarrantsByStockId(int stockId)
    {
        return await _dbContext.CoveredWarrants
            .Where(c=>c.UnderlyingAssetId == stockId)
            .Include(c=>c.UnderlyingAsset)
            .ToListAsync();
    }
}
