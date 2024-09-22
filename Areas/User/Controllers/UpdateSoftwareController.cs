using Microsoft.AspNetCore.Mvc;

namespace DATAspNetCoreMVCMaxton.Areas.User.Controllers
{
    [Area("User")]
    public class UpdateSoftwareController : Controller
    {
        public IActionResult TimelineSoft()
        {
            return View();
        }
    }
}
