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

        private readonly IProfileGroupBLL _profileGroupBLL; // Assuming you have a service for handling profile groups
        private readonly IProfileOrbitasBLL _profileOrbitaBLL; // Assuming you have a service for handling profile orbitas
        public HomeController(ILogger<HomeController> logger, IProfileGroupBLL profileGroupService, IProfileOrbitasBLL profileOrbitaService)
        {
            _logger = logger;
            _profileGroupBLL = profileGroupService;
            _profileOrbitaBLL = profileOrbitaService;
        }

		public async Task<IActionResult> Index()
		{
			var model = new _UserMainDTO
			{
				ProfileGroupSelectList = await _profileGroupBLL.CreateProfileGroupSelectListAsync(),
				ProfileOrbitas = new List<ProfileOrbitaDTO>() // Không hiển thị dữ liệu khi chưa chọn nhóm
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
            var profileOrbitas = await _profileOrbitaBLL.GetProfileOrbitasByGroupAsync(profileGroupId);
            return Json(profileOrbitas); // Trả về dữ liệu dưới dạng JSON
        }

        //public async Task<IActionResult> Index()
        //{
        //    var profileOrbitas = await _profileOrbitaService.GetAll_ProfileOrbita_List();

        //    var profileGroups = await _profileGroupService.GetProfileGroupsAsync();
        //    var model = new _UserMainDTO
        //    {
        //        ProfileGroupSelectList = profileGroups.Select(pg => new SelectListItem
        //        {
        //            Value = pg.Id.ToString(),
        //            Text = pg.Name
        //        }).ToList(),

        //        ProfileOrbitas = profileOrbitas.ToList() // Assuming GetProfileOrbitasAsync returns an IEnumerable<ProfileOrbitaDTO>
        //    };

        //    return View(model);
        //}



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
