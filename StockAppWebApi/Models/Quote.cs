namespace StockAppWebApi.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Quote
{
    [Key]
    [Column("quote_id")]
    public int QuoteId { get; set; }

    [Required(ErrorMessage = "Stock ID is required.")]
    [ForeignKey("Stock")]
    [Column("stock_id")]
    public int StockId { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Column("price")]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Change is required.")]
    [Column("change")]
    [Range(0, double.MaxValue, ErrorMessage = "Change must be a non-negative value.")]
    public decimal Change { get; set; }

    [Required(ErrorMessage = "Percent change is required.")]
    [Column("percent_change")]
    [Range(0, 100, ErrorMessage = "Percent change must be between 0 and 100.")]
    public decimal PercentChange { get; set; }

    [Required(ErrorMessage = "Volume is required.")]
    [Column("volume")]
    public int Volume { get; set; }

    [Required(ErrorMessage = "Timestamp is required.")]
    [Column("time_stamp")]
    public DateTime TimeStamp { get; set; }

    // Navigation property
    public Stock? Stock { get; set; }
}
