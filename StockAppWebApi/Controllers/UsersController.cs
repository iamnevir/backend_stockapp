using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Models;
using StockAppWebApi.Services;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                Username = model.Username,
                HashedPassword = model.Password, // You should hash the password before storing it
                Email = model.Email,
                Phone = model.Phone,
                FullName = model.FullName,
                DateOfBirth = model.DateOfBirth,
                Country = model.Country
            };

            var result = await _userService.Register(user);
            return CreatedAtAction(nameof(Register), new { id = result.UserId }, result);
        }
        catch (ArgumentException e)
        {

            return BadRequest(new { e.Message });
        }
        
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string token = await _userService.Login(loginViewModel);
            return Ok( new { token });
        }
        catch (ArgumentException e)
        {

            return BadRequest(new { e.Message });
        }
    }
}   
