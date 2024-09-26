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

        private readonly IUserAccountService _userAccountService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserAccountController(IUserAccountService userBll,IWebHostEnvironment webHostEnvironment)
        {
            _userAccountService = userBll;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: UserAccount/BasicUserAccount
        [HttpGet]
        public async Task<IActionResult> BasicUserAccount()
        {
            var userAccount = await _userAccountService.GetUserAccountByIdAsync(1);
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
        public async Task<IActionResult> EditUserAccount(_UserMainDTO userMainDTO, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    // Save the image to wwwroot/uploads
                    var uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    var filePath = Path.Combine(uploadsDir, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                    userMainDTO.UserAccount.Avatar = "/uploads/" + uniqueFileName;
    
                }

                await _userAccountService.UpdateUserAccountAsync(userMainDTO.UserAccount);
                return RedirectToAction(nameof(BasicUserAccount), "UserAccount", new { area = "User" });
            }
            return View(userMainDTO);
        }
        public IActionResult SecurityUserAccount() { return View(); }
    }
}
