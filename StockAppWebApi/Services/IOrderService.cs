using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Services;

public interface IOrderService
{
    Task<Order> CreateOrder(OrderViewModel orderViewModel);
}
