using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DATAspNetCoreMVCMaxton.Controllers
{
    public class AuthController(SignInManager<AppUserDTO> signInManager, UserManager<AppUserDTO> userManager) : Controller
    {
        public IActionResult Basiclogin(){ return View();}
        public async Task<IActionResult> BasicLogout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
