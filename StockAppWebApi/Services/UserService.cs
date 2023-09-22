using StockAppWebApi.Models;
using StockAppWebApi.Repositories;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Register(User user)
    {
        var existUserName = await _userRepository.GetUserByName(user.Username);
        if (existUserName != null)
        {
            throw new ArgumentException("UserName already exists");
        }
        var existUserEmail = await _userRepository.GetUserByEmail(user.Email);
        if (existUserEmail != null)
        {
            throw new ArgumentException("Email already exists");
        }
        return await _userRepository.Register(user);
    }

    public async Task<User> GetUserById(int id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task<User> GetUserByName(string name)
    {
        return await _userRepository.GetUserByName(name);
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await _userRepository.GetUserByEmail(email);
    }
    public async Task<string> Login(LoginViewModel loginViewModel)
    {
        return await _userRepository.Login(loginViewModel);
    }
}
