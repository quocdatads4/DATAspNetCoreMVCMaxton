namespace DATAspNetCoreMVCMaxton.Areas.User.Models
{
    public class ErrorViewDTO
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
