using Microsoft.AspNetCore.Identity;

namespace DATAspNetCoreMVCMaxton.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string? ApiKey { get; set; }
	}
}
