namespace CounThings.Application.Commands.Requests
{
    public class CreateActivityRequest
    {
        public string Name { get; set; } = "";
        public bool ItsCalculable { get; set; }
    }
}
