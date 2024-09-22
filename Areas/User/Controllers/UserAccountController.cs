using DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using DATAspNetCoreMVCMaxton.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Controllers
{
    [Area("User")]
    public class UserAccountController : Controller
    {

        private readonly IUserAccountService _userBll;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserAccountController(IUserAccountService userBll, IWebHostEnvironment webHostEnvironment)
        {
            _userBll = userBll;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: UserAccount/BasicUserAccount
        [HttpGet]
        public async Task<IActionResult> BasicUserAccount()
        {
            var userAccount = await _userBll.GetUserAccountByIdAsync(1);
            if (userAccount == null)
            {
                return NotFound();
            }

            var viewMainVM = new _UserMainDTO
            {
                UserAccount = userAccount
            };

            return View(viewMainVM);
        }
        [HttpPost]
        public async Task<IActionResult> UploadAvatar(IFormFile avatar, int userAccountId)
        {
            if (avatar != null && (avatar.ContentType == "image/png" || avatar.ContentType == "image/jpeg"))
            {
                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(avatar.FileName)}";
                var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "avatars", fileName);

                using (var fileStream = new FileStream(uploadPath, FileMode.Create))
                {
                    await avatar.CopyToAsync(fileStream);
                }

                var userAccount = await _userBll.GetUserAccountByIdAsync(userAccountId);
                userAccount.Avatar = $"/uploads/avatars/{fileName}";

                await _userBll.UpdateUserAccountAsync(userAccount);

                return RedirectToAction("BasicUserAccount");
            }

            return BadRequest("Invalid file format or upload failed.");
        }
        public IActionResult SecurityUserAccount() { return View(); }

    }
}
