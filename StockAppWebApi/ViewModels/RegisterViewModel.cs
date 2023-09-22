using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.ViewModels;

public class RegisterViewModel
{
    [MaxLength(100)]
    public required string Username { get; set; }

    [MaxLength(200)]
    public required string Password { get; set; }

    [MaxLength(255)]
    [EmailAddress]
    public required string Email { get; set; }

    [MaxLength(20)]
    [Phone]
    public required string Phone { get; set; }

    [MaxLength(255)]
    public string? FullName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    [MaxLength(200)]
    public string? Country { get; set; }
}
