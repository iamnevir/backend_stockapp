using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly StockAppDbContext _stockAppDbContext;
    public OrderRepository(StockAppDbContext stockAppDbContext)
    {
        _stockAppDbContext = stockAppDbContext;

    }
    public async Task<Order> CreateOrder(OrderViewModel orderViewModel)
    {
        Order order = new()
        {
            UserId = orderViewModel.UserId,
            StockId = orderViewModel.StockId,
            Quantity = orderViewModel.Quantity,
            Price = orderViewModel.Price,
            OrderType = orderViewModel.OrderType,
            Direction = orderViewModel.Direction,
            OrderDate = DateTime.Now
        };
        _stockAppDbContext.Orders.Add(order);
        await _stockAppDbContext.SaveChangesAsync();
        return order;
    }
}
