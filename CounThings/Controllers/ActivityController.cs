using Microsoft.AspNetCore.Mvc;

namespace CounThings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
 
        [HttpGet(Name = "Teste")]
        public IActionResult Get()
        {
            return Ok("Oi Larissa!!");
        }
    }
}