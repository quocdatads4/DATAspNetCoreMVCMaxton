using Microsoft.AspNetCore.Identity;

namespace DATAspNetCoreMVCMaxton.Models
{
	public class ApplicationUserModel : IdentityUser
	{
		public string? ApiKey { get; set; }
	}
}
