using CounThings.Application.Commands.Handlers.Interfaces.Payment;
using CounThings.Application.Commands.Handlers.PaymentHandler;
using CounThings.Application.Commands.Requests.Payment;
using Microsoft.AspNetCore.Mvc;

namespace CounThings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ICreatePaymentHandler _createPaymentHandler;
        private readonly IDeletePaymentHandler _deletePaymentHandler;

        public PaymentController(ICreatePaymentHandler createPaymentHandler, IDeletePaymentHandler deletePaymentHandler)
        {
            _createPaymentHandler = createPaymentHandler;
            _deletePaymentHandler = deletePaymentHandler;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreatePaymentRequest command)
        {
            var response = await _createPaymentHandler.Handle(command);
            return Ok(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _deletePaymentHandler.Handler(id);
            return Ok(response.Message);
        }

    }
}
