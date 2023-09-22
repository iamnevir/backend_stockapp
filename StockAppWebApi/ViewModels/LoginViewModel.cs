using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.ViewModels;

public class LoginViewModel
{
    [EmailAddress]
    public required string Email { get; set; }
    public required string Password { get; set; }
}
