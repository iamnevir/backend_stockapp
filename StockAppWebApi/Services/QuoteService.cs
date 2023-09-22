using StockAppWebApi.Models;
using StockAppWebApi.Repositories;

namespace StockAppWebApi.Services;

public class QuoteService : IQuoteService
{
    private readonly IQuoteRepository _quoteRepository;
    public QuoteService(IQuoteRepository quoteRepository)
    {
        _quoteRepository = quoteRepository;
    }

    public async Task<List<Quote>> GetHistoricalQuotes(int days, int stockId)
    {
        return await _quoteRepository.GetHistoricalQuotes(days, stockId);
    }

    public async Task<List<ViewQuotesRealtime>?> GetViewQuotesRealtimes(
        int page, 
        int limit, 
        string sector, 
        string industry)
    {
        return await _quoteRepository.GetViewQuotesRealtimes(
            page, 
            limit, 
            sector,
            industry);
    }
}
