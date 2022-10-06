using Prj.Net6.APIJWTRefreshToke.Entities;
using Prj.Net6.APIJWTRefreshToke.Models.Users;

namespace Prj.Net6.APIJWTRefreshToke.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
