using CounThings.Domain.Models;

namespace CounThings.Application.Commands.Responses.Payment
{
    public class CreatePaymentResponse
    {
        public int Id { get; set; }
        public double AmountPaid { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
