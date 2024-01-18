using CounThings.Domain.Commands.Handlers.Interfaces;
using CounThings.Domain.Commands.Requests;
using CounThings.Domain.Commands.Responses;
using CounThings.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounThings.Domain.Commands.Handlers
{
    public class CreateActivityHandler : ICreateActivityHandler
    {
        public CreateActivityResponse Handle(CreateActivityRequest command)
        {
            var activity = new Activity(command.Name, command.Quantity, command.Amount.GetValueOrDefault(), command.ItsCalculable);

            return new CreateActivityResponse
            {
                
            };
        }
    }
}
