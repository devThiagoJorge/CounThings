namespace CounThings.Application.Commands.Responses.Payment
{
    public class ListPaymentResponse
    {
        public int Id { get; set; }
        public double AmountPaid { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ActivityId { get; set; }
    }
}
