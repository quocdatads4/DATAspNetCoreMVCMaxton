using Microsoft.AspNetCore.Mvc;

namespace DATAspNetCoreMVCMaxton.Areas.User.Controllers
{
    public class SocialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
