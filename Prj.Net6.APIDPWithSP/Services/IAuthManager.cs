using Dapper;
using Prj.Net6.APIDPWithSP.Models;

namespace Prj.Net6.APIDPWithSP.Services
{
    public interface IAuthManager
    {
        Response<string> GenerateJWT(User user);
        Response<T> Execute_Command<T>(string query, DynamicParameters sp_params);
        Response<List<T>> getUserList<T>();
    }
}
