using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Repositories;

public interface IUserRepository
{
    Task<User?> Register(User user);
    Task<User?> GetUserById(int id);
    Task<User?> GetUserByName(string name);
    Task<User?> GetUserByEmail(string email);

    Task<string> Login(LoginViewModel loginViewModel);
}
