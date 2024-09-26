using DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATAspNetCoreMVCMaxton.Areas.User.Controllers
{
    [Area("User")]

    public class HotmailOutlookController : Controller
	{
        private readonly IHotmailOutlookService _hotmailOutlookAccountService;
        public HotmailOutlookController(IHotmailOutlookService hotmailOutlookService)
        {
            _hotmailOutlookAccountService = hotmailOutlookService;
        }
        // Action để lấy danh sách Facebook Account
        [HttpGet]
        public async Task<IActionResult> TableHotmailOutlook()
        {

            var model = new _UserMainDTO
            {
                HotmailOutlookList = await _hotmailOutlookAccountService.GetAllHotmailOutlookAccountAsync()
            };
            return View(model);
        }
    }

   
}
