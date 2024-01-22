using CounThings.Application.Commands.Requests;
using CounThings.Application.Commands.Requests.Payment;
using CounThings.Application.Commands.Responses;
using CounThings.Application.Commands.Responses.Payment;

namespace CounThings.Application.Commands.Handlers.Interfaces.Payment
{
    public interface ICreatePaymentHandler
    {
        public Task<ApiResponse> Handle(CreatePaymentRequest command);
    }
}
