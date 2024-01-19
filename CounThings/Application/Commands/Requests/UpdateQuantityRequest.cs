namespace CounThings.Application.Commands.Requests
{
    public class UpdateQuantityRequest
    {
        public bool AddNew { get; set; } = false;
        public int ActivityId { get; set; }
    }
}
