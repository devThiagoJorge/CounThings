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
        private readonly IActivityQueryHandler _queryHandler;
        private readonly IActivityRepository _repository;


        public ActivityController(ICreateActivityHandler createHandler, 
            IActivityRepository repository,
            IUpdateQuantityInActivityHandler updateQuantityHandler,
            IActivityQueryHandler queryHandler)
        {
            _createHandler = createHandler;
            _repository = repository;
            _updateQuantityHandler = updateQuantityHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var activity = await _queryHandler.HandleGetActivityById(id);
            return Ok(activity);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var activies = await _queryHandler.HandleGetAllActivies();

            return Ok(activies);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateActivityRequest command)
        {
            var response = await _createHandler.Handle(command);
            return Ok(response);
        }


        [HttpPut("UpdateQuantityInActivity")]
        public async Task<IActionResult> UpdateQuantityInActivity(UpdateQuantityRequest command)
        {
            var response = await _updateQuantityHandler.Handle(command);
            return Ok(response);
        }
    }
}