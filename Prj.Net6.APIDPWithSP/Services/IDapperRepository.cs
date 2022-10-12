using Dapper;
using System.Data;

namespace Prj.Net6.APIDPWithSP.Services
{
    public interface IDapperRepository
    {
        T execute_sp<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
        T GetByID<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
    }
}
