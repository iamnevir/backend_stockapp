using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;

namespace StockAppWebApi.Repositories;

public class WatListRepository:IWatListRepository
{
    private readonly StockAppDbContext _context;

    public WatListRepository(StockAppDbContext context)
    {
        _context = context;
    }
    public async Task AddStockToWatchList(int userId,int stockId)
    {
        var watchList= await _context.WatchLists.FindAsync(userId, stockId);
        if (watchList is null)
        {
            watchList = new WatchList
            {
                UserId = userId,
                StockId = stockId
            };
            _context.WatchLists.Add(watchList);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<WatchList?> GetWatchListItem(int userId, int stockId)
    {
        return await _context.WatchLists.FirstOrDefaultAsync(watchList 
            => watchList.UserId == userId && watchList.StockId == stockId); 
    }
}
