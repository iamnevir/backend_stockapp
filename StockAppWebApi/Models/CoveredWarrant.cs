namespace StockAppWebApi.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CoveredWarrant
{
    [Key]
    [Column("warrant_id")]
    public int WarrantId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [Column("name")]
    [MaxLength(255)]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Underlying asset ID is required.")]
    [ForeignKey("UnderlyingAsset")]
    [Column("underlying_asset_id")]
    public int UnderlyingAssetId { get; set; }

    [Column("issue_date")]
    public DateTime? IssueDate { get; set; }

    [Column("expiration_date")]
    public DateTime? ExpirationDate { get; set; }

    [Column("strike_price")]
    public decimal? StrikePrice { get; set; }

    [Column("warrant_type")]
    [MaxLength(50)]
    public string? WarrantType { get; set; }

    // Navigation property
    public Stock? UnderlyingAsset { get; set; }
}
