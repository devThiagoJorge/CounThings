using CounThings.Application.Commands.Responses.Payment;

namespace CounThings.Application.Commands.Responses
{
    public class ActivityQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Quantity { get; set; }
        public double? Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool ItsCalculable { get; set; }
        public ICollection<ListPaymentResponse>? Payments { get; set; }
    }
}
