using Auction.API.Communication.Requests;
using Auction.API.Contracts;
using Auction.API.Entities;
using Auction.API.Repositories;
using Auction.API.Services;

namespace Auction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IOfferRepository _offerRepository;
    
    public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository offerRepository)
    {
        _loggedUser = loggedUser;
        _offerRepository = offerRepository;
    }
    
    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var today = new DateTime(2024, 01, 22);

        var user = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = today,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };
        
        _offerRepository.Add(offer);
        
        return offer.Id;
    }
}