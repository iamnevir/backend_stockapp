using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories;

public class StockRepository: IStockRepository
{
    private readonly StockAppDbContext _context;

    public StockRepository(StockAppDbContext context)
    {
        _context = context;
    }
    public async Task<Stock?> GetStockById(int id)
    {
        return await _context.Stocks.FindAsync(id);
    }

    public async Task<Stock?> GetStockByCompanyName(string companyName)
    {
        return await _context.Stocks.FirstOrDefaultAsync(u => u.CompanyName == companyName);
    }
}
