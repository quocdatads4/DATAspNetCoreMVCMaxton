using DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic;
using DATAspNetCoreMVCMaxton.Areas.User.Data;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Controllers
{
    [Area("User")]
    public class FacebookAccountController : Controller
    {
        private readonly IFacebookAccountService _facebookAccountService;
        public FacebookAccountController(IFacebookAccountService facebookAccountService)
        {
            _facebookAccountService = facebookAccountService;
        }
        // Action để lấy danh sách Facebook Account
        [HttpGet]
        public async Task<IActionResult> TableFacebookAccount()
        {

            var model = new _UserMainDTO
            {
                FacebookAccountList = await _facebookAccountService.GetAllFacebookAccountAsync()
            };
            return View(model);
        }
        //[HttpPost]
        //public async Task<IActionResult> SaveSettingsFacebookAccountView(_UserMainDTO model)
        //{
        //    // Chuyển đổi từ ViewModel sang Model
        //    var accountView = new _UserMainDTO
        //    {

        //        Avatar = model.Avatar,
        //        UId = model.UId,
        //        // ... chuyển đổi các thuộc tính khác
        //    };

        //    // Lưu vào database
        //    // Giả sử bạn có một instance của DbContext tên là _context
        //    _context.AspFacebookAccountViews.Add(accountView);
        //    await _context.SaveChangesAsync();

        //    // Quay trở lại trang trước hoặc thông báo thành công
        //    return RedirectToAction("Index"); // Thay "Index" bằng tên action/view mà bạn muốn quay lại
        //}


    }
}
