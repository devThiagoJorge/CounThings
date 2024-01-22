using CounThings.Application.Commands.Requests.Payment;

namespace CounThings.Application.Commands.Handlers.Interfaces.Payment
{
    public interface IDeletePaymentHandler
    {
        public Task<ApiResponse> Handler(int id);
    }
}
