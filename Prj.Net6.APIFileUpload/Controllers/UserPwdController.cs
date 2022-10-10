using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prj.Net6.APIFileUpload.Resources;
using Prj.Net6.APIFileUpload.Services;

namespace Prj.Net6.APIFileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPwdController : ControllerBase
    {
        private readonly ILogger<UserPwdController> _logger;
        private readonly IUserService _userService;

        public UserPwdController(ILogger<UserPwdController> logger,IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterResource resource, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _userService.Register(resource, cancellationToken);
                _logger.LogInformation("Resource (Register) : " + resource.Username.ToString());
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("Error : " + e.Message);
                return BadRequest(new { ErrorMessage = e.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginResource resource, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _userService.Login(resource, cancellationToken);
                _logger.LogInformation("Resource (Login) : " + resource.Username.ToString());
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("Error : " + e.Message);
                return BadRequest(new { ErrorMessage = e.Message });
            }
        }
    }
}
