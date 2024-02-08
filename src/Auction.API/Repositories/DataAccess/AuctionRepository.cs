using Auction.API.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly AuctionDbContext _dbContext;
    
    public AuctionRepository(AuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Entities.Auction? GetCurrent()
    {
        var today = new DateTime(2024, 01, 22);
        return _dbContext.Auctions.Include(auction => auction.Items).FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}