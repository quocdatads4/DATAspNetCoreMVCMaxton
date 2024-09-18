using DATAspNetCoreMVCMaxton.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DATAspNetCoreMVCMaxton.Controllers
{
    public class AuthController(SignInManager<ApplicationUserModel> signInManager, UserManager<ApplicationUserModel> userManager) : Controller
    {
        public IActionResult Basiclogin(){ return View();}
        public async Task<IActionResult> BasicLogout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
