using AutoMapper;
using CounThings.Application.Commands.Responses;
using CounThings.Domain.Models;

namespace CounThings.Application.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper() {
            CreateMap<Activity, ActivityQueryResponse>()
                .ReverseMap();
        }
    }
}
