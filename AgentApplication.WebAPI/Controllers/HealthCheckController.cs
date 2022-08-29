using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AgentApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class HealthCheckController : ControllerBase
    {
        public HealthCheckController() { }

        [HttpGet]
        public ActionResult HealthCheck()
        {
            return Ok();
        }
    }
}
