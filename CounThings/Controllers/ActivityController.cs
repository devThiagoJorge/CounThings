using CounThings.Application.Commands.Handlers.Interfaces;
using CounThings.Application.Commands.Requests;
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
        public async Task<IActionResult> Create([FromBody] CreateActivityRequest command)
        {
            var response = await _handler.Handle(command);
            return Ok(response);
        }
    }
}