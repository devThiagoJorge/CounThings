using CounThings.Domain.Commands.Handlers.Interfaces;
using CounThings.Domain.Commands.Requests;
using CounThings.Domain.Models;
using CounThings.Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace CounThings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly ICreateActivityHandler _handler; 

        public ActivityController(ICreateActivityHandler handler)
        {
            _handler= handler;
        }
 
        [HttpPost]
        public IActionResult Create([FromBody] CreateActivityRequest command)
        {
            var response = _handler.Handle(command);
            return Ok(response);
        }
    }
}