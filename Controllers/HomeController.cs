using DATAspNetCoreMVCMaxton.BusinessLogic;
using DATAspNetCoreMVCMaxton.DataAccess;
using DATAspNetCoreMVCMaxton.Models;
using DATAspNetCoreMVCMaxton.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace DATAspNetCoreMVCMaxton.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public List<ProfileGroupDTO> ProfileGroups { get; set; }
        public List<ProfileOrbitaDTO> ProfileOrbitas { get; set; }

        private readonly IProfileGroupService _profileGroupService;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IProfileGroupService profileGroupService)
        {
            _logger = logger;
            _context = context;
            _profileGroupService = profileGroupService;
        }

        public async Task<IActionResult> Index()
        {

            var profileOrbitas = await GetProfileOrbitasAsync();

            int profileCount = profileOrbitas.Count;

            // Sử dụng async await để nhận danh sách SelectListItem
            var profileGroupSelectList = await CreateProfileGroupSelectList();

            var dashboardModel = CreateDashboardModel(profileGroupSelectList, profileOrbitas);

            // Điền dữ liệu cần thiết vào từng model
            // ...

            var viewMainVM = new MainVM
            {
                Dashboard = dashboardModel,
            };

            return View(viewMainVM);

        }
        private async Task<List<SelectListItem>> CreateProfileGroupSelectList()
        {
            return await _profileGroupService.CreateProfileGroupSelectListAsync();
        }


        // Phương thức này lấy danh sách các ProfileOrbita từ cơ sở dữ liệu
        private async Task<List<ProfileOrbitaDTO>> GetProfileOrbitasAsync()
        {
            return await _context.AspNetProfileOrbita.ToListAsync();
        }

        // Phương thức này tạo DashboardModel từ các tham số đầu vào
        private DashboardModel CreateDashboardModel(List<SelectListItem> profileGroupSelectList, List<ProfileOrbitaDTO> profileOrbitas)
        {
            return new DashboardModel
            {
                ProfileGroupSelectList = profileGroupSelectList,
                ProfileOrbitas = profileOrbitas
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
