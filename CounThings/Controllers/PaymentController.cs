using CounThings.Application.Commands.Handlers.Interfaces.Payment;
using CounThings.Application.Commands.Requests.Payment;
using Microsoft.AspNetCore.Mvc;

namespace CounThings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ICreatePaymentHandler _createPaymentHandler;
        public PaymentController(ICreatePaymentHandler createPaymentHandler)
        {
            _createPaymentHandler = createPaymentHandler;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreatePaymentRequest command)
        {
            var response = await _createPaymentHandler.Handle(command);
            return Ok(response);
        }
    }
}
