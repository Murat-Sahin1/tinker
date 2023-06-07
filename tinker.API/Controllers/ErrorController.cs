using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace tinker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        public ErrorController()
        {
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretText() 
        {
            return "secret stuff";
        }
    }
}
