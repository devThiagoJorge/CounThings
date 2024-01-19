using CounThings.Application.Commands.Responses;

namespace CounThings.Application.Commands.Handlers.Interfaces
{
    public interface IActivityQueryHandler
    {
        public Task<ActivityQueryResponse> HandleGetActivityById(int id);
        public Task<IList<ActivityQueryResponse>> HandleGetAllActivies();

    }
}
