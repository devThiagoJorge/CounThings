using CounThings.Application.Commands.Requests;
using CounThings.Application.Commands.Responses;

namespace CounThings.Application.Commands.Handlers.Interfaces
{
    public interface IUpdateQuantityInActivityHandler
    {
        Task<ApiResponse> Handle(UpdateQuantityRequest command);
    }
}
