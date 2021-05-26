using System;
using Microsoft.AspNetCore.Mvc;

namespace UTMAPP.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/")]
    public class MainController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetApiInfo()
        {
            return Ok(new
            {
                Version = "1.0.0",
                nameof = "Calculate values",
                SwaggerSchema = "/swagger"
            });
        }
    }
}
