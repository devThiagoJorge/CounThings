using CounThings.Application.Commands.Handlers.Interfaces;
using CounThings.Application.Commands.Requests;
using CounThings.Application.Commands.Responses;
using CounThings.Domain.Models;
using CounThings.Infra.Repositories.Abstractions;

namespace CounThings.Application.Commands.Handlers
{
    public class CreateActivityHandler : ICreateActivityHandler
    {
        private readonly IActivityRepository _repository;

        public CreateActivityHandler(IActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateActivityResponse> Handle(CreateActivityRequest command)
        {
            var activity = new Activity(command.Name, command.ItsCalculable);

            var activityCreated = await _repository.AddActivity(activity);

            return new CreateActivityResponse
            {
                Id = activityCreated.Id,
                ItsCalculable = activityCreated.ItsCalculable,
                Amount = activityCreated.Amount.GetValueOrDefault(),
                CreatedAt = activityCreated.CreatedAt,
                Name = activityCreated.Name,
                Quantity = activityCreated.Quantity
            };

        }
    }
}
