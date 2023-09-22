using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories;

public class QuoteRepository : IQuoteRepository
{
    private readonly StockAppDbContext _context;
    public QuoteRepository(StockAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Quote>> GetHistoricalQuotes(int days, int stockId)
    {
        var fromDate = DateTime.Now.Date.AddDays(-days);
        var toDate = DateTime.Now.Date;
        var historicalQuotes = await _context.Quotes
            .Where(q => q.TimeStamp >= fromDate
            && q.TimeStamp <= toDate
            && q.StockId == stockId)
            .GroupBy(q => q.TimeStamp.Date)
            .Select(g => new Quote
            {
                TimeStamp = g.Key,
                StockId = stockId,
            })
            .OrderBy(q => q.TimeStamp)
            .ToListAsync();
        return historicalQuotes;
    }

    public async Task<List<ViewQuotesRealtime>?> GetViewQuotesRealtimes(
        int page,
        int limit, 
        string sector, 
        string industry)
    {

        var query = _context.ViewQuotesRealtimes
            .Skip((page - 1) * limit)
            .Take(limit);
        if(!string.IsNullOrEmpty(sector))
        {
            query = query.Where(q=>(q.Sector??"").ToLower().Equals(sector.ToLower()));
        }
        if (!string.IsNullOrEmpty(industry))
        {
            query = query.Where(q => q.Industry==industry);
        }
        var quotes = await query.ToListAsync();
        return quotes;
    }
}
