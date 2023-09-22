using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;
using StockAppWebApi.Repositories;

namespace StockAppWebApi.Services;

public class WatchListService: IWatchListService
{
    private readonly IWatListRepository _repository;
    public WatchListService(IWatListRepository repository)
    {
        _repository = repository;
    }
    public async Task AddStockToWatchList(int userId, int stockId)
    {
       await _repository.AddStockToWatchList(userId, stockId);   
    }

    public async Task<WatchList> GetWatchListItem(int userId, int stockId)
    {
       return await _repository.GetWatchListItem(userId, stockId);
    }
}
