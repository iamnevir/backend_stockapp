namespace StockAppWebApi.Models;

using Microsoft.EntityFrameworkCore;

public class StockAppDbContext : DbContext
{
    public StockAppDbContext(DbContextOptions<StockAppDbContext> options) 
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<WatchList> WatchLists { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<WatchList>().HasKey(w => new {w.UserId,w.StockId});
        modelBuilder.Entity<Order>().ToTable(table=>table.HasTrigger("trigger_oders"));
    }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<ViewQuotesRealtime> ViewQuotesRealtimes { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CoveredWarrant> CoveredWarrants { get; set; }
}
