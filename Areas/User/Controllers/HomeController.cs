using DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic;
using DATAspNetCoreMVCMaxton.Areas.User.Data;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DATAspNetCoreMVCMaxton.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProfileGroupService _profileGroupService; // Assuming you have a service for handling profile groups
        private readonly IProfileOrbitasBLL _profileOrbitaService; // Assuming you have a service for handling profile orbitas
        private readonly IFacebookAccountService _facebookAccountService;
        public HomeController(ILogger<HomeController> logger, 
            IProfileGroupService profileGroupService, 
            IProfileOrbitasBLL profileOrbitaService, 
            IFacebookAccountService facebookAccountService)
        {
            _logger = logger;
            _profileGroupService = profileGroupService;
            _profileOrbitaService = profileOrbitaService;
            _facebookAccountService = facebookAccountService;
        }

		public async Task<IActionResult> Index()
		{
            var model = new _UserMainDTO
            {
                ProfileGroupSelectList = await _profileGroupService.CreateProfileGroupSelectListAsync(),
                ProfileOrbitasList = await _profileOrbitaService.GetAll_ProfileOrbita_List(),
            };

			return View(model);
		}

        // Action để lấy danh sách ProfileOrbita theo ProfileGroupId
        [HttpGet]
        public async Task<IActionResult> GetProfileOrbitasByGroup(int profileGroupId)
        {
            if (profileGroupId == 0) // Kiểm tra nếu ID nhóm không hợp lệ
            {
                return Json(new List<ProfileOrbitaDTO>()); // Trả về danh sách trống
            }

            // Gọi hàm từ BLL để lấy danh sách ProfileOrbita theo nhóm
            var profileOrbitas = await _profileOrbitaService.GetProfileOrbitasByGroupAsync(profileGroupId);
            return Json(profileOrbitas); // Trả về dữ liệu dưới dạng JSON
        }
        // Action để lấy danh sách Facebook Account
        [HttpGet]
        public async Task<IActionResult> GetFacebookAccountList()
        {

            // Gọi hàm từ BLL để lấy danh sách Facebook Account
            var facebookAccount = await _facebookAccountService.GetAllFacebookAccountList();
            return Json(facebookAccount); // Trả về dữ liệu dưới dạng JSON
        }
        // Action để lấy danh sách Facebook Account
        [HttpGet]
        public async Task<IActionResult> GetProfileGroupList()
        {

            // Gọi hàm từ BLL để lấy danh sách Facebook Account
            var profileGroup = await _profileGroupService.GetProfileGroupsAsync();
            return Json(profileGroup); // Trả về dữ liệu dưới dạng JSON
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> EditProfileOrbita([FromBody] _UserMainDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _profileOrbitaService.EditProfileOrbitaAsyncTable(model);
                if (result)
                    return Ok(true); // Trả về HTTP 200 cùng với dữ liệu thành công
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewDTO { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
