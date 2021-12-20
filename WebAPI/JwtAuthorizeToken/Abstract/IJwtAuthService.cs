
namespace WebAPI.JwtAuthorizeToken.Abstract
{
    public interface IJwtAuthService
    {
        string Authenticate(string username, string password);
    }
}
