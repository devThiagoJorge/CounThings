using CounThings.Domain.Models;
using CounThings.Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace CounThings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly ActivityContext _context;

        public ActivityController(ActivityContext context)
        {
            _context= context;
        }
 
        [HttpGet(Name = "Teste")]
        public IActionResult Get()
        {
            _context.Activities.Add(new Activity
            {
                Amount= 10,
                CreatedAt= DateTime.Now,
                ItsCalculable = true,
                Name = "Testando",
                Quantity = 20
            });

            _context.SaveChanges();

            return Ok(_context.Activities.ToList());
        }
    }
}