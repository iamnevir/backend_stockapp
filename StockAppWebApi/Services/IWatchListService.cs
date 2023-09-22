using StockAppWebApi.Models;

namespace StockAppWebApi.Services;

public interface IWatchListService
{
    Task AddStockToWatchList(int userId, int stockId);
    Task<WatchList> GetWatchListItem(int userId, int stockId);
}
