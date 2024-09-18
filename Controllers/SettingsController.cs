using Microsoft.AspNetCore.Mvc;

namespace DATAspNetCoreMVCMaxton.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult SettingsIndexView()
        {
            return View();
        }
    }
}
