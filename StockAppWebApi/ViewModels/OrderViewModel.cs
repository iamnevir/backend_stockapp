using StockAppWebApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockAppWebApi.ViewModels;

public class OrderViewModel
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int StockId { get; set; }

    [Required(ErrorMessage = "OrderType is required.")]
    public string? OrderType { get; set; }

    [Required(ErrorMessage = "Direction is required.")]
    public Direction Direction { get; set; }

    [Range(1, int.MaxValue,
        ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; set; }

    public decimal Price { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    public string? Status { get; set; }
}
