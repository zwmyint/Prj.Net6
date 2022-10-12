using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prj.Net6.APIDPWithSP.Models;
using Prj.Net6.APIDPWithSP.Services;
using System.Data;

namespace Prj.Net6.APIDPWithSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _authentication;

        public AccountController(IAuthManager authentication)
        {
            _authentication = authentication;
        }

        //
        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult login([FromBody] LoginModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Parameter is missing");
            }

            DynamicParameters dp_param = new DynamicParameters();
            dp_param.Add("email", user.email, DbType.String);
            dp_param.Add("password", user.password, DbType.String);
            dp_param.Add("retVal", DbType.String, direction: ParameterDirection.Output);
            var result = _authentication.Execute_Command<User>("sp_loginUser", dp_param);
            if (result.code == 200)
            {
                var token = _authentication.GenerateJWT(result.Data);
                return Ok(token);
            }
            return NotFound(result.Data);
        }

        [HttpGet("UserList")]
        //[Authorize(Roles = "User")]
        public IActionResult getAllUsers()
        {
            var result = _authentication.getUserList<User>();
            return Ok(result);
        }

        [HttpPost("Register")]
        //[Authorize(Roles = "Admin")]
        public IActionResult Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Parameter is missing");
            }

            DynamicParameters dp_param = new DynamicParameters();
            dp_param.Add("email", user.Email, DbType.String);
            dp_param.Add("username", user.Username, DbType.String);
            dp_param.Add("password", user.Password, DbType.String);
            dp_param.Add("role", user.Role, DbType.String);
            dp_param.Add("retVal", DbType.String, direction: ParameterDirection.Output);
            var result = _authentication.Execute_Command<User>("sp_registerUser", dp_param);
            if (result.code == 200)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        //[Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            if (id == string.Empty)
            {
                return BadRequest("Parameter is missing");
            }

            DynamicParameters dp_param = new DynamicParameters();
            dp_param.Add("userid", id, DbType.String);

            dp_param.Add("retVal", DbType.String, direction: ParameterDirection.Output);
            var result = _authentication.Execute_Command<User>("sp_deleteUser", dp_param);
            if (result.code == 200)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        //
    }
}
