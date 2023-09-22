using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories;

public interface IWatListRepository
{
    Task AddStockToWatchList(int userId, int stockId);
    Task<WatchList> GetWatchListItem(int userId, int stockId);
}
