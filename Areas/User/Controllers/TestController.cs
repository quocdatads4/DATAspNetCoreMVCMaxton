using DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace DATAspNetCoreMVCMaxton.Areas.User.Controllers
{
    [Area("User")]
    public class TestController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProfileGroupService _profileGroupService; // Assuming you have a service for handling profile groups
        private readonly IProfileOrbitasService _profileOrbitaService; // Assuming you have a service for handling profile orbitas
        private readonly IFacebookAccountService _facebookAccountService;
        private readonly IGoogleAccountService _googleAccountService;
        private readonly IHotmailOutlookService _hotmailOutlookService;
        public TestController(ILogger<TestController> logger,
            IProfileGroupService profileGroupService,
            IProfileOrbitasService profileOrbitaService,
            IFacebookAccountService facebookAccountService,
            IGoogleAccountService googleAccountService,
            IHotmailOutlookService hotmailOutlookService)
        {
            _profileGroupService = profileGroupService;
            _profileOrbitaService = profileOrbitaService;
            _facebookAccountService = facebookAccountService;
            _googleAccountService = googleAccountService;
            _hotmailOutlookService = hotmailOutlookService;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new _UserMainDTO();  // Khởi tạo object

            // Kiểm tra và xử lý từng service
            if (_profileGroupService != null)
            {
                try
                {
                    model.ProfileGroupSelectList = await _profileGroupService.CreateProfileGroupSelectListAsync();
                    model.ProfileGroupSelectbyID = await _profileGroupService.CreateProfileGroupSelectListAsync();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ProfileGroupSelectList", "Không thể tải danh sách nhóm hồ sơ");
                    Console.WriteLine($"Error loading ProfileGroupSelectList: {ex.Message}");
                }
            }
            else
            {
                ModelState.AddModelError("ProfileGroupService", "Service không khả dụng");
            }

            if (_profileOrbitaService != null)
            {
                try
                {
                    model.ProfileOrbitasList = await _profileOrbitaService.GetAllProfileOrbitaList();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ProfileOrbitasList", "Không thể tải danh sách Profile Orbita");
                    Console.WriteLine($"Error loading ProfileOrbitasList: {ex.Message}");
                }
            }
            else
            {
                ModelState.AddModelError("ProfileOrbitaService", "Service không khả dụng");
            }

            if (_facebookAccountService != null)
            {
                try
                {
                    model.FacebookAccountList = await _facebookAccountService.GetAllFacebookAccountAsync();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("FacebookAccountList", "Không thể tải danh sách tài khoản Facebook");
                    Console.WriteLine($"Error loading FacebookAccountList: {ex.Message}");
                }
            }
            else
            {
                ModelState.AddModelError("FacebookAccountService", "Service không khả dụng");
            }

            if (_googleAccountService != null)
            {
                try
                {

                    model.GoogleAccountList = await _googleAccountService.GetAllGoogleAccountAsync();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("GoogleAccountList", "Không thể tải danh sách tài khoản Google");
                    Console.WriteLine($"Error loading GoogleAccountList: {ex.Message}");
                }
            }
            else
            {
                ModelState.AddModelError("GoogleAccountService", "Service không khả dụng");
            }
            if (_hotmailOutlookService != null)
            {
                try
                {

                    model.HotmailOutlookList = await _hotmailOutlookService.GetAllHotmailOutlookAccountAsync();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("HotmailOutlookList", "Không thể tải danh sách tài khoản Google");
                    Console.WriteLine($"Error loading HotmailOutlookList: {ex.Message}");
                }
            }
            else
            {
                ModelState.AddModelError("HotmailOutlookService", "Service không khả dụng");
            }
            return View(model);
        }
        
    }
}
