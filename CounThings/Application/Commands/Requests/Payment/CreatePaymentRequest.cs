namespace CounThings.Application.Commands.Requests.Payment
{
    public class CreatePaymentRequest
    {
        public double AmountPaid { get; set; }
        public int ActivityId { get; set; }
    }
}
