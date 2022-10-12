using Prj.Net6.APIBasicAuth2.Entities;

namespace Prj.Net6.APIBasicAuth2.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
}
