using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebApi.Models;
[Table("users")]
public class User
{
    [Key]
    [Column("user_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    [MaxLength(100, ErrorMessage = "Username cannot exceed 100 characters.")]
    [Column("username")]
    public required string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [MaxLength(200, ErrorMessage = "Password cannot exceed 200 characters.")]
    [Column("hashed_password")]
    public required string HashedPassword { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [MaxLength(255, ErrorMessage = "Email cannot exceed 255 characters.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    [Column("email")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [MaxLength(20, ErrorMessage = "Phone number cannot exceed 20 digits.")]
    [RegularExpression(@"^\+?\d{8,15}$",ErrorMessage = "Invalid Phone Number.")]
    [Column("phone")]
    public required string Phone { get; set; }

    [MaxLength(255, ErrorMessage = "Full name cannot exceed 255 characters.")]
    [Column("full_name")]
    public string? FullName { get; set; }

    [Column("date_of_birth")]
    public DateTime? DateOfBirth { get; set; }

    [MaxLength(200, ErrorMessage = "Country name cannot exceed 200 characters.")]
    [Column("country")]
    public string? Country { get; set; }

    public ICollection<WatchList>? WatchLists { get; set; }
    public ICollection<Order>? Orders { get; set; }
}