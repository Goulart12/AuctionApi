using Microsoft.EntityFrameworkCore;

namespace Auction.API.Repositories;

public class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Entities.Auction> Auctions { get; set; }
    public DbSet<Entities.User> Users{ get; set; }
    public DbSet<Entities.Offer> Offers { get; set; }
}