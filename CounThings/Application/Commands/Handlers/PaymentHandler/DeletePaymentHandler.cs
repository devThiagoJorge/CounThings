using CounThings.Application.Commands.Handlers.Interfaces.Payment;
using CounThings.Application.Commands.Requests.Payment;
using CounThings.Infra.Repositories.Abstractions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CounThings.Application.Commands.Handlers.PaymentHandler
{
    public class DeletePaymentHandler : IDeletePaymentHandler
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IPaymentRepository _paymentRepository;
        public DeletePaymentHandler(IActivityRepository activityRepository, IPaymentRepository paymentRepository)
        {
            _activityRepository = activityRepository;
            _paymentRepository = paymentRepository;
        }
        public async Task<ApiResponse> Handler(int id)
        {
            var payment = await _paymentRepository.GetPaymentById(id);

            if(payment == null)
                return new ApiResponse(false, "Pagamento não encontrada!");

            var activity = await _activityRepository.GetActivityById(payment.ActivityId);

            if (activity == null)
                return new ApiResponse(false, "Atividade não encontrada!");


            await _paymentRepository.Delete(id);

            bool isNew = false;
            activity.UpdateQuantityActivity(isNew);
            activity.UpdateTotal(payment.AmountPaid, isNew);

            await _activityRepository.UpdateActivity(activity);

            return new ApiResponse(true, "A atividade foi removida.");
        }
    }
}
