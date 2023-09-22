using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebApi.Models;

[Table("orders")]
public class Order
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [ForeignKey("User")]
    [Column("user_id")]
    public int UserId { get; set; }

    [ForeignKey("Stock")]
    [Column("stock_id")]
    public int StockId { get; set; }

    [Column("order_type")]
    [Required(ErrorMessage = "OrderType is required.")]
    public string? OrderType { get; set; }

    [Column("direction")]
    [Required(ErrorMessage ="Direction is required.")]
    public Direction Direction { get; set; }

    [Range(1,int.MaxValue,
        ErrorMessage ="Quantity must be greater than 0")]
    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

    [Column("status")]
    [Required(ErrorMessage = "Status is required.")]
    public string? Status { get; set; }

    [Column("order_date")]
    public DateTime? OrderDate { get; set; }

    public Stock? Stock { get; set; }

    public User? User { get; set; }
}
public enum Direction
{
    Buy,
    Sell
}