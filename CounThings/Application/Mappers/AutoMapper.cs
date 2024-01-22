using AutoMapper;
using CounThings.Application.Commands.Responses;
using CounThings.Application.Commands.Responses.Payment;
using CounThings.Domain.Models;

namespace CounThings.Application.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper() {
            CreateMap<Activity, ActivityQueryResponse>()
                .ReverseMap();

            CreateMap<Payment, CreatePaymentResponse>()
               .ReverseMap();

            CreateMap<Payment, ListPaymentResponse>()
                .ReverseMap();
        }
    }
}
