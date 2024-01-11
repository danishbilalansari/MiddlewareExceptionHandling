using Microsoft.AspNetCore.Mvc;
using MiddlewareExceptionHandling.Services;

namespace MiddlewareExceptionHandling.Controller
{
    [ApiController]
    public class CustomController : ControllerBase
    {
        private readonly PingService _someService;

        public CustomController(PingService someService)
        {
            _someService = someService;
        }

        [HttpGet("ping")]
        public ActionResult<string> Ping()
        {
            return Ok(_someService.Ping());
        }
    }
}
