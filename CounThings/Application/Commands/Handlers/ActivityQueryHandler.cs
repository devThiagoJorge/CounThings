using AutoMapper;
using CounThings.Application.Commands.Handlers.Interfaces;
using CounThings.Application.Commands.Responses;
using CounThings.Infra.Repositories.Abstractions;
using Microsoft.Extensions.Logging;

namespace CounThings.Application.Commands.Handlers
{
    public class ActivityQueryHandler : IActivityQueryHandler
    {
        private readonly IActivityRepository _repository;
        private readonly IMapper _mapper;

        public ActivityQueryHandler(IActivityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ActivityQueryResponse> HandleGetActivityById(int id)
        {
            var activity = await _repository.GetActivityById(id);
            var activityData = _mapper.Map<ActivityQueryResponse>(activity);

            return activityData;
        }

        public async Task<IList<ActivityQueryResponse>> HandleGetAllActivies()
        {
            var activies = await _repository.GetAll();
            var activiesData = _mapper.Map<IList<ActivityQueryResponse>>(activies);

            return activiesData;
        }
    }
}
