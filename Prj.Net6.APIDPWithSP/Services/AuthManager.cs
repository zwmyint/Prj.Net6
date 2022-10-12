using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Prj.Net6.APIDPWithSP.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Prj.Net6.APIDPWithSP.Services
{
    public class AuthManager : IAuthManager
    {

        private readonly IOptions<ReaderModel> _option;

        public AuthManager(IOptions<ReaderModel> options)
        {
            _option = options;
        }

        public Response<string> GenerateJWT(User user)
        {
            Response<string> response = new Response<string>();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsSecretKey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //claim is used to add identity to JWT token
            var claims = new[] {
                 new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                 new Claim(JwtRegisteredClaimNames.Email, user.Email),
                 new Claim("roles", user.Role),
                 new Claim("Date", DateTime.Now.ToString()),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            var token = new JwtSecurityToken("ThisIsIssuer", "ThisIsIssuer",
              claims,    //null original value
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            response.Data = new JwtSecurityTokenHandler().WriteToken(token); //return access token
            response.code = 200;
            response.message = "Token generated";
            return response;
        }

        public Response<T> Execute_Command<T>(string query, DynamicParameters sp_params)
        {
            Response<T> response = new Response<T>();
            using (IDbConnection dbConnection = new SqlConnection(_option.Value.DefaultConnection))
            {
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();
                using var transaction = dbConnection.BeginTransaction();
                try
                {
                    response.Data = dbConnection.Query<T>(query, sp_params, commandType: CommandType.StoredProcedure, transaction: transaction).FirstOrDefault();
                    response.code = sp_params.Get<int>("retVal"); //get output parameter value
                    response.message = "Success";
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    response.code = 500;
                    response.message = ex.Message;
                }
            }
            return response;
        }

        public Response<List<T>> getUserList<T>()
        {
            Response<List<T>> response = new Response<List<T>>();
            using IDbConnection db = new SqlConnection(_option.Value.DefaultConnection);
            string query = "Select userid,username,email,[role],reg_date FROM tbl_users";
            response.Data = db.Query<T>(query, null, commandType: CommandType.Text).ToList();
            return response;
        }

        //
    }
}
