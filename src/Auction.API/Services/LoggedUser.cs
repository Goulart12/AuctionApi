using Auction.API.Contracts;
using Auction.API.Entities;
using Auction.API.Repositories;

namespace Auction.API.Services;

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;

    public LoggedUser(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
    }

    public User User()
    {
        var token = TokenOnRequest();
        var email = FromBase64String(token);

        return _userRepository.GetUserByEmail(email);
    }
    
    private string TokenOnRequest()
    {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authentication["Bearer ".Length..];
    }

    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);
        
        return System.Text.Encoding.UTF8.GetString(data);
    }
}