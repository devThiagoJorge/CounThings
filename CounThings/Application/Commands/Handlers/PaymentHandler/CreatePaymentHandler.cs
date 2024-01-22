using AutoMapper;
using CounThings.Application.Commands.Handlers.Interfaces.Payment;
using CounThings.Application.Commands.Requests;
using CounThings.Application.Commands.Requests.Payment;
using CounThings.Application.Commands.Responses;
using CounThings.Application.Commands.Responses.Payment;
using CounThings.Domain.Models;
using CounThings.Infra.Repositories.Abstractions;
using System.Diagnostics;

namespace CounThings.Application.Commands.Handlers.PaymentHandler
{
    public class CreatePaymentHandler : ICreatePaymentHandler
    {
        private readonly IPaymentRepository _repository;
        private readonly IMapper _mapper;
        public CreatePaymentHandler(IPaymentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatePaymentResponse> Handle(CreatePaymentRequest command)
        {
            var payment = new Payment(command.AmountPaid, command.ActivityId);
            var paymentCreated = await _repository.AddPayment(payment);

            var paymentData = _mapper.Map<CreatePaymentResponse>(paymentCreated);
            return paymentData;
        }
    }
}
