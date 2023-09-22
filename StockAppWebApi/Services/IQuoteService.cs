using StockAppWebApi.Models;

namespace StockAppWebApi.Services;

public interface IQuoteService
{
    Task<List<ViewQuotesRealtime>?> GetViewQuotesRealtimes(
        int page,
        int limit,
        string sector,
        string industry);

    Task<List<Quote>> GetHistoricalQuotes(int days, int stockId);
}
