namespace Auction.API.Contracts;

public interface IAuctionRepository
{
    Entities.Auction? GetCurrent();
}