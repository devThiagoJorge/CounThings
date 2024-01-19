using CounThings.Application.Commands.Handlers.Interfaces;
using CounThings.Application.Commands.Requests;
using CounThings.Domain.Models;
using CounThings.Infra.Context;
using CounThings.Infra.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CounThings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly ICreateActivityHandler _createHandler;
        private readonly IUpdateQuantityInActivityHandler _updateQuantityHandler;
        private readonly IActivityRepository _repository;

        public ActivityController(ICreateActivityHandler createHandler, 
            IActivityRepository repository,
            IUpdateQuantityInActivityHandler updateQuantityHandler)
        {
            _createHandler = createHandler;
            _repository = repository;
            _updateQuantityHandler = updateQuantityHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateActivityRequest command)
        {
            var response = await _createHandler.Handle(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var a = await _repository.GetActivityById(id);
            return Ok(a);
        }


        [HttpPut("UpdateQuantityInActivity")]
        public async Task<IActionResult> UpdateQuantityInActivity(UpdateQuantityRequest command)
        {
            var response = await _updateQuantityHandler.Handle(command);
            return Ok(response);
        }
    }
}