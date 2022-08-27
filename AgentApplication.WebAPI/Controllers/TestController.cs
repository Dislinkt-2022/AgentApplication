using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AgentApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class TestController : ControllerBase
    {
        public TestController() { }

        [Authorize(Roles = "Administrator")]
        [HttpGet("Administrator")]
        public ActionResult AuthorizeAdministrator()
        {
            return Ok();
        }

        [Authorize(Roles = "User")]
        [HttpGet("User")]
        public ActionResult AuthorizeUser()
        {
            return Ok();
        }

        [HttpGet("AllowAnonymous")]
        public ActionResult AllowAnonymous()
        {
            return Ok();
        }
    }
}
