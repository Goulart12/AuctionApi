

using Auction.API.Contracts;
using Auction.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Auction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IAuctionRepository _auctionRepository;

    public GetCurrentAuctionUseCase(IAuctionRepository auctionRepository)
    {
        _auctionRepository = auctionRepository;
    }
    public Entities.Auction? Execute()
    {
        return _auctionRepository.GetCurrent();
    }
}