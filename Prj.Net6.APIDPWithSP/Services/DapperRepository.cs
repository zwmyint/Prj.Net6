using Dapper;
using Microsoft.Extensions.Options;
using Prj.Net6.APIDPWithSP.Models;
using System.Data;
using System.Data.SqlClient;

namespace Prj.Net6.APIDPWithSP.Services
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IOptions<ReaderModel> _option;

        public DapperRepository(IConfiguration configuration, IOptions<ReaderModel> options)
        {
            _configuration = configuration;
            _option = options;
        }

        public List<T> GetAll<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
        {
            //using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using IDbConnection db = new SqlConnection(_option.Value.DefaultConnection);
            
                return db.Query<T>(query, sp_params, commandType: commandType).ToList();
        }

        public T GetByID<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_option.Value.DefaultConnection);
            return db.Query<T>(query, sp_params, commandType: commandType).FirstOrDefault();
        }

        public T execute_sp<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;

            using (IDbConnection dbConnection = new SqlConnection(_option.Value.DefaultConnection))
            {
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();

                using var transaction = dbConnection.BeginTransaction();
                try
                {
                    dbConnection.Query<T>(query, sp_params, commandType: commandType, transaction: transaction);

                    result = sp_params.Get<T>("retVal"); //get output parameter value

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error-" + ex.Message);
                }
            };

            return result;
        }


    }
}
