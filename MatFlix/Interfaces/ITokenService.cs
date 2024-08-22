using MatFlix.Models;

namespace MatFlix.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}