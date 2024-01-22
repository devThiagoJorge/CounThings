using AutoMapper;
using CounThings.Application.Commands.Handlers.Interfaces.Payment;
using CounThings.Application.Commands.Requests.Payment;
using CounThings.Application.Commands.Responses.Payment;
using CounThings.Domain.Models;
using CounThings.Infra.Repositories.Abstractions;

namespace CounThings.Application.Commands.Handlers.PaymentHandler
{
    public class CreatePaymentHandler : ICreatePaymentHandler
    {
        private readonly IPaymentRepository _repository;
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;
        public CreatePaymentHandler(IPaymentRepository repository, 
            IMapper mapper,
            IActivityRepository activityRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _activityRepository = activityRepository;
        }

        public async Task<ApiResponse> Handle(CreatePaymentRequest command)
        {
            var activity = await _activityRepository.GetActivityById(command.ActivityId);

            if (activity == null)
                return new ApiResponse(false, "Atividade não encontrada!");

            if(!activity.ItsCalculable)
                return new ApiResponse(false, "Atividade não pode ser contabilizada!");

            var payment = new Payment(command.AmountPaid, command.ActivityId);
            var paymentCreated = await _repository.AddPayment(payment);
            var paymentData = _mapper.Map<CreatePaymentResponse>(paymentCreated);

            bool addNew = true;
            activity.UpdateQuantityActivity(addNew);
            activity.UpdateTotal(paymentData.AmountPaid, addNew);

            await _activityRepository.UpdateActivity(activity);

            return new ApiResponse(true, $"Novo registro de R${paymentData.AmountPaid} foi inserido!");
        }
    }
}
