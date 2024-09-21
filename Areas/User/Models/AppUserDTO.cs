using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DATAspNetCoreMVCMaxton.Areas.User.Models
{
    [Area("User")]
    public class AppUserDTO : IdentityUser
    {
        public string? ApiKey { get; set; }
    }
}
