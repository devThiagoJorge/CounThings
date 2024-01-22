using CounThings.Application.Commands.Handlers.Interfaces;
using CounThings.Application.Commands.Requests;
using CounThings.Infra.Repositories.Abstractions;

namespace CounThings.Application.Commands.Handlers
{
    public class UpdateQuantityInActivityHandler : IUpdateQuantityInActivityHandler
    {
        private readonly IActivityRepository _activityRepository;
        public UpdateQuantityInActivityHandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<ApiResponse> Handle(UpdateQuantityRequest command)
        {
            var activity = await _activityRepository.GetActivityById(command.ActivityId);

            if (activity.Quantity == 0 && !command.AddNew)
                return new ApiResponse(true, $"A atividade {activity.Name} já está com 0 frequência!");

            activity.UpdateQuantityActivity(command.AddNew);

            await _activityRepository.UpdateActivity(activity);

            return new ApiResponse(true, $"A atividade {activity.Name} - {activity.Quantity} foi atualizado!");
        }
    }
}
