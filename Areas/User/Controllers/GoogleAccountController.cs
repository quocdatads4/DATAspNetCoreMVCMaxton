using DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATAspNetCoreMVCMaxton.Areas.User.Controllers
{
    [Area("User")]

    public class GoogleAccountController : Controller
    {
        private readonly IGoogleAccountService _googleAccountService;
        public GoogleAccountController(IGoogleAccountService googleAccountService)
        {
            _googleAccountService = googleAccountService;
        }
        // Action để lấy danh sách Facebook Account
        [HttpGet]
        public async Task<IActionResult> TableGoogleAccount()
        {
            var model = new _UserMainDTO
            {
                GoogleAccountList = await _googleAccountService.GetAllGoogleAccountAsync()
            };
            return View(model);
        }

    }
}
