using System.Collections.Generic;

namespace Prj.Net6.APIBasicAuth
{
    public interface IUserRepository
    {
        Task<bool> Authenticate(string username, string password);
        Task<User> Authenticate2(string username, string password);
        Task<List<User>> GetUserNames();
        Task<IEnumerable<User>> GetAll();

    }
}
