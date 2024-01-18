using CounThings.Domain.Commands.Requests;
using CounThings.Domain.Commands.Responses;

namespace CounThings.Domain.Commands.Handlers.Interfaces
{
    public interface ICreateActivityHandler
    {
        CreateActivityResponse Handle(CreateActivityRequest command);
    }
}
