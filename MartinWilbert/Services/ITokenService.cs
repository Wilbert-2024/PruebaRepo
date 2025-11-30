using MartinWilbert.Models;

namespace MartinWilbert.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        string GeneratePasswordResetToken();


    }
}
