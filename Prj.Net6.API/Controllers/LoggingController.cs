using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prj.Net6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] KeyValueRequest request)
        {
            Response.Headers.Add("my-response-header", "My response header");
            return Ok(request);
        }

        //
        // https://medium.com/@luisalexandre.rodrigues/logging-http-request-and-response-in-net-web-api-268135dcb27b
        //
    }
}
