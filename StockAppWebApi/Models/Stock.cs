namespace StockAppWebApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("stocks")]
public class Stock
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("stock_id")]
    public int StockId { get; set; }

    [Required(ErrorMessage = "Symbol is required.")]
    [Column("symbol")]
    [MaxLength(10)]
    public required string Symbol { get; set; }

    [Required(ErrorMessage = "Company name is required.")]
    [Column("company_name")]
    [MaxLength(255)]
    public required string CompanyName { get; set; }

    [Column("market_cap")]
    public decimal? MarketCap { get; set; }

    [Column("sector")]
    [MaxLength(200)]
    public string? Sector { get; set; }

    [Column("industry")]
    [MaxLength(200)]
    public string? Industry { get; set; }

    [Column("sector_en")]
    [MaxLength(200)]
    public string? SectorEn { get; set; }

    [Column("industry_en")]
    [MaxLength(200)]
    public string? IndustryEn { get; set; }

    [Column("stock_type")]
    [MaxLength(50)]
    public string? StockType { get; set; }

    [Column("rank")]
    [Range(0, int.MaxValue)]
    public int Rank { get; set; }

    [Column("rank_source")]
    [MaxLength(200)]
    public string? RankSource { get; set; }

    [Column("reason")]
    [MaxLength(255)]
    public string? Reason { get; set; }
    public ICollection<WatchList>? WatchLists { get; set; }

    public ICollection<Order>? Orders { get; set; }
    public ICollection<Quote>? Quotes { get; set; }
    public ICollection<CoveredWarrant>? CoveredWarrants { get; set; }
}
