using DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace DATAspNetCoreMVCMaxton.Areas.User.Controllers
{
    [Area("User")]
    public class FacebookAccountViewController : Controller
    {
        private readonly IFacebookAccountViewService _facebookAccountViewService;
        public FacebookAccountViewController(IFacebookAccountViewService facebookAccountViewService)
        {
            _facebookAccountViewService = facebookAccountViewService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
