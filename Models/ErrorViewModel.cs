namespace ContosoUniversity.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestID => !string.IsNullOrEmpty(RequestId);
    }
}
